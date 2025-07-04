﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Identity.Abstractions
{
    /// <summary>
    /// Options passed-in to call downstream web APIs.
    /// </summary>
    /// <example>
    /// <format type="text/markdown">
    /// <![CDATA[
    /// Here is an example of a configuration of a downstream API that would retrieve
    /// the user profile (it's illustrated with Microsoft Graph as this is a well-known API, but of course
    /// to effectively call Microsoft graph, rather use Microsoft.Identity.Web.MicrosoftGraph)
    /// 
    /// ```json
    ///  "DownstreamApis": [
    ///     "MyProfile": {
    ///        "BaseUrl": "https://graph.microsoft.com/v1.0",
    ///        "RelativePath": "/me/profile",
    ///         "Scopes": [ "user.read"],
    ///         "ExtraHeaderParameters": {
    ///           "OData-Version": "4.0"
    ///         },
    ///         "ExtraQueryParameters": {
    ///           "filter": "displayName eq 'John'"
    ///         }
    ///     }
    ///   ]
    /// ```
    /// 
    /// The following describes a downstream web API called on behalf of the application itself (application token)
    /// and using the Pop protocol:
    /// ```json
    ///  "DownstreamApis": [
    ///     "AllBooks": {
    ///        "BaseUrl": "https://mylibrary.com",
    ///        "RelativePath": "/books/all",
    ///        "RequestAppToken": true,
    ///        "ProtocolScheme": "Pop",
    ///         "Scopes": ["https://mylibrary.com/.default"],
    ///         "ExtraHeaderParameters": {
    ///           "X-API-Version": "v2"
    ///         },
    ///         "ExtraQueryParameters": {
    ///           "format": "json"
    ///         }
    ///     }
    ///   ]
    /// ```
    /// ]]></format>
    /// </example>
    public class DownstreamApiOptions : AuthorizationHeaderProviderOptions
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DownstreamApiOptions()
        {
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="other"></param>
        public DownstreamApiOptions(DownstreamApiOptions other) : base(other)
        {
            Scopes = other.Scopes;
            Serializer = other.Serializer;
            Deserializer = other.Deserializer;
            AcceptHeader = other.AcceptHeader;
            ContentType = other.ContentType;
            ExtraHeaderParameters = other.ExtraHeaderParameters;
            ExtraQueryParameters = other.ExtraQueryParameters;
        }

        /// <summary>
        /// Clone the options (to be able to override them).
        /// </summary>
        /// <returns>A clone of the options.</returns>
        public new DownstreamApiOptions Clone()
        {
            return (CloneInternal() as DownstreamApiOptions)!;
        }

        /// <inheritdoc/>
        protected override AuthorizationHeaderProviderOptions CloneInternal()
        {
            return new DownstreamApiOptions(this);
        }

        /// <summary>
        /// Scopes required to call the downstream web API.
        /// For instance "user.read mail.read".
        /// For Microsoft identity, in the case of application tokens (token 
        /// requested by the app on behalf of itself), there should be only one scope, and it
        /// should end in "./default")
        /// </summary>
        public IEnumerable<string>? Scopes { get; set; }

        /// <summary>
        /// Optional serializer. Will serialize the input to the web API (if any).
        /// By default, when not provided:
        /// <list type="bullet">
        /// <item><description>If the input derives from <c>HttpInput</c>, it's used as is</description></item>
        /// <item><description>If the input is a string it's used as is an considered a media type json.</description></item>
        /// <item><description>Otherwise, the object is serialized in JSON, with a UTF8 encoding, and a media
        /// type of application/json:
        /// <code>
        /// new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json")
        /// </code>
        /// </description></item>
        /// </list>
        /// </summary>
        /// <remarks>This property cannot be set in the configuration. It's code only.</remarks>
        public Func<object?, HttpContent?>? Serializer { get; set; }

        /// <summary>
        /// Optional de-serializer. Will de-serialize the output from the web API (if any).
        /// When not provided, the following is returned:
        /// <code>JsonSerializer.Deserialize&lt;TOutput&gt;(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });</code>
        /// </summary>
        /// <remarks>This property cannot be set in the configuration. It's code only.</remarks>
        public Func<HttpContent?, object?>? Deserializer { get; set; }

        /// <summary>
        /// The HTTP Accept header is used to inform that server about the content type
        /// that the client is expecting in the response.
        /// </summary>
        /// <default>application/json</default>
        public string AcceptHeader { get; set; } = "application/json";

        /// <summary>
        /// Content type of the request body.
        /// </summary>
        /// <default>application/json</default>
        public string ContentType { get; set; } = "application/json";

        /// <summary>
        /// Sets extra headers in the HTTP request to the downstream web API. This should
        /// not be confused with another option to set the headers in the request to the 
        /// Identity Provider. See <see cref="AcquireTokenOptions.ExtraHeadersParameters"/> for 
        /// that scenario.
        /// </summary>
        public IDictionary<string, string>? ExtraHeaderParameters { get; set; }

        /// <summary>
        /// Sets query parameters for the query string in the HTTP request to the 
        /// downstream web API. This should not be confused with another option to set the 
        /// query parameters in the request to the Identity Provider. See 
        /// <see cref="AcquireTokenOptions.ExtraQueryParameters"/> for that scenario.
        /// </summary>
        public IDictionary<string, string>? ExtraQueryParameters { get; set; }
    }
}
