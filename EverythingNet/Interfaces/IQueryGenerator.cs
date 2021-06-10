namespace EverythingNet.Interfaces
{
  using System.Collections.Generic;

  public interface IQueryGenerator
  {
    RequestFlags Flags { get; }

    IEnumerable<string> GetQueryParts();
  }
}