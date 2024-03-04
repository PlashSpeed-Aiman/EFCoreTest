namespace EFCoreTest.ResponseObject;

public struct ResponseStruct
{
    public string StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }
    public ResponseStruct(bool success, string message, object? data, string statusCode)
    {
        StatusCode = statusCode;
        IsSuccess = success;
        Message = message;
        Data = data;
    }
 
}

 
