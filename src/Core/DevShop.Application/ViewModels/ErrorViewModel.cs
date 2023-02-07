using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevShop.Application.ViewModels
{
    public class ErrorViewModel
{
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    public Exception Exception { get; set; }

    public int? StatusCode { get; set; }
}
}