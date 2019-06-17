﻿using System.Collections.Generic;
using System.Linq;
using Popcorn.Utils.Interfaces;

namespace Popcorn.Utils.ResponseProcessors
{
    internal class TrimProcessor : IResponseProcessor
	{
		StandardResponse IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode, string splitRegEx)
		{
			IResponseProcessor response = new StandardResponse();

			var entries = new List<string>();
			entries = responseLines.Skip(3).Where(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.Trim()).ToList();

			var respObj = response.ProcessResponse(entries, exitCode);
			respObj.ResponseObject = entries;
			return respObj;
		}
	}
}