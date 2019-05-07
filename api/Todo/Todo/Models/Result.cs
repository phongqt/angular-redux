using System;

namespace Todo.Models
{
  public class Result
  {
    public bool Success { get; set; }
    public string Message { get; set; }
    public dynamic Data { get; set; }
  }
}
