using EasyKeys.Veeqo.Abstractions.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyKeys.Veeqo.LineItems;

public interface IVeeqoLineItemsClient
{
    Task<VeeqoResult<bool>> UpdateLineItemNotesAsync(int lineItemId, string note, CancellationToken cancellationToken = default);
}
