﻿using System;
using Popcorn.Utils.Attributes;
using Popcorn.Utils.Interfaces;
using Popcorn.Utils.ResponseProcessors;

namespace Popcorn.Utils.Actions.HTTP
{
    public interface IShowAction
	{
		/// <summary>
		/// Lists all resources and their associated properties that are cached in the HTTP response cache or displays a single resource and its associated properties.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307240(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="url">Fully qualified URL. If unspecified, implies all URLs. The URL can also be a prefix to registered URLs.</param>
		[MethodName("cachestate")]
		[ResponseProcessor(typeof(BlockProcessor), @":\s+")]
		IResponse CacheState([ParameterName("url")] String url = null);

		/// <summary>
		/// Lists all IP addresses in the IP listen list. The IP listen list is used to scope the list of addresses to which the HTTP service binds. "0.0.0.0" means any IPv4 address and "::" means any IPv6 address.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307241(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		[MethodName("iplisten")]
		[ResponseProcessor(typeof(TrimProcessor))]
		IResponse IpListen();

		/// <summary>
		/// Shows a snapshot of the HTTP service using the Session view
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307242(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="verbose">View verbose information showing property information too.</param>
		[MethodName("servicestate view=session")]
		[ResponseProcessor(typeof(TabulatedObjectProcessor), @":\s+")]
		IResponse ServiceStateSessionView([ParameterName("verbose")] Boolean? verbose = null);

		/// <summary>
		/// Shows a snapshot of the HTTP service using the Request Queue view
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307242(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="verbose">View verbose information showing property information too.</param>
		[MethodName("servicestate view=requestq")]
		[ResponseProcessor(typeof(TabulatedObjectProcessor), @":\s+")]
		IResponse ServiceStateRequestQueueView([ParameterName("verbose")] Boolean? verbose = null);

		/// <summary>
		/// Lists SSL server certificate bindings and the corresponding client certificate policies for an IP address/hostname and port. Not specifying an ipport or hostnameport lists all bindings.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307243(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="ipPort">Specifies the IPv4 or IPv6 address and port for which the SSL certificate bindings will be displayed.</param>
		/// <param name="hostnamePort">Specifies the hostname and port for which the SSL certificate bindings will be displayed.</param>
		[MethodName("sslcert")]
		[ResponseProcessor(typeof(BlockProcessor), @"\s+:\s+")]
		IResponse SSLCert([ParameterName("ipport")] string ipPort = null, [ParameterName("hostnameport")] string hostnamePort = null);

		/// <summary>
		/// Shows the timeout values of the service (in seconds).
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307244(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		[MethodName("timeout")]
		[ResponseProcessor(typeof(BlockProcessor), @":\s+")]
		IResponse Timeout();

		/// <summary>
		/// Lists DACLs for the specified reserved URL or all reserved URLs.
		/// See <a href="https://msdn.microsoft.com/en-us/library/windows/desktop/cc307245(v=vs.85).aspx">MSDN</a>.
		/// </summary>
		/// <param name="url">Specifies the fully qualified URL. If unspecified, implies all URLs.</param>
		[MethodName("urlacl")]
		[ResponseProcessor(typeof(TabulatedObjectProcessor), @":\s+")]
		IResponse UrlAcl([ParameterName("url")] String url = null);
	}
}