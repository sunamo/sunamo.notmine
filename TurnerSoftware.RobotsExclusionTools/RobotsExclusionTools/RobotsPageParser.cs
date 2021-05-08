﻿using System;
using System.Collections.Generic;
using System.Text;
using TurnerSoftware.RobotsExclusionTools.Tokenization;
using TurnerSoftware.RobotsExclusionTools.Tokenization.Tokenizers;
using TurnerSoftware.RobotsExclusionTools.Tokenization.TokenParsers;
using TurnerSoftware.RobotsExclusionTools.Tokenization.Validators;

namespace TurnerSoftware.RobotsExclusionTools
{
	public class RobotsPageParser : IRobotsPageDefinitionParser
	{
		private ITokenizer Tokenizer { get; }
		private ITokenPatternValidator PatternValidator { get; }
		private IRobotsPageTokenParser TokenParser { get; }

		public RobotsPageParser() : this(new RobotsPageTokenizer(), new RobotsPageTokenPatternValidator(), new RobotsPageTokenParser()) { }

		public RobotsPageParser(ITokenizer tokenizer, ITokenPatternValidator patternValidator, IRobotsPageTokenParser tokenParser)
		{
			Tokenizer = tokenizer ?? throw new ArgumentNullException(nameof(tokenizer));
			PatternValidator = patternValidator ?? throw new ArgumentNullException(nameof(patternValidator));
			TokenParser = tokenParser ?? throw new ArgumentNullException(nameof(tokenParser));
		}
		
		public RobotsPageDefinition FromRules(IEnumerable<string> rules)
		{
			var tokens = new List<Token>();
			foreach (var ruleLine in rules)
			{
				tokens.AddRange(Tokenizer.Tokenize(ruleLine));
				tokens.Add(Token.NewLineToken);
			}

			return FromTokens(tokens);
		}
		
		private RobotsPageDefinition FromTokens(IEnumerable<Token> tokens)
		{
			var validationResult = PatternValidator.Validate(tokens);

			if (validationResult.IsValid)
			{
				return new RobotsPageDefinition
				{
					PageAccessEntries = TokenParser.GetPageAccessEntries(tokens)
				};
			}

			return new RobotsPageDefinition();
		}
	}
}