using System;

namespace RichLife.infrastructure.Models
{
    /// <summary>
    /// Базовая модель ответа
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        public BaseResponse()
        {

        }
        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        public BaseResponse(bool result)
        {
            IsSuccess = result;
        }
        /// <summary>
        /// Для ошибок строквых
        /// </summary>
        /// <param name="error"></param>
        public BaseResponse(string error)
        {
            Error = error;
        }
        /// <summary>
        /// Для перехвата Exception
        /// </summary>
        /// <param name="ex"></param>
        public BaseResponse(Exception ex) 
            : this(ex.Message ?? "Internal Server Error")
        {

        }
        /// <summary>
        /// Верно ли выполнился метод
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Ошибка для выводв/ демага
        /// </summary>
        public string Error { get; set; }
    }
    /// <summary>
    /// Базовая модель ответа
    /// </summary>
    public class BaseResponse<T>:BaseResponse
    {
        /// <summary>
        /// Для ошибок строквых
        /// </summary>
        /// <param name="error"></param>
        public BaseResponse(string error)
        {
            Error = error;
        }
        /// <summary>
        /// Для перехвата Exception
        /// </summary>
        /// <param name="ex"></param>
        public BaseResponse(Exception ex)
            : this(ex.Message ?? "Internal Server Error")
        {

        }
        /// <summary>
        /// Вернуть конкретную модель
        /// </summary>
        /// <param name="data"></param>
        public BaseResponse(T data)
        {
            IsSuccess = true;
            Data = data;
        }
        /// <summary>
        /// Ответ
        /// </summary>
        public T Data { get; set; }
    }
}
