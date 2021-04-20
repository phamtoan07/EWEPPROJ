namespace Eweb.Controllers.Base
{
    /// <summary>
    /// Represents base grandnode entity model
    /// </summary>
    public interface IBaseController
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        string CoreAdd();
        string CoreEdit();
        string CoreDelete();
        string CoreInquiry();
        string Adhoc();
    }
}