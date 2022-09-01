using Newtonsoft.Json;

namespace Haru.Models.EFT
{
    public struct ResponseModel<T>
    {
        [JsonProperty("err")]
        public int ErrorCode;

        [JsonProperty("errmsg")]
        public string ErrorMessage;

        [JsonProperty("data")]
        public T Data;

        [JsonProperty("crc")]
        public long Crc;

        public ResponseModel(T data, long crc = 0)
        {
            ErrorCode = 0;
            ErrorMessage = null;
            Data = data;
            Crc = crc;
        }

        public ResponseModel(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Data = default(T);
            Crc = 0;
        }
    }
}