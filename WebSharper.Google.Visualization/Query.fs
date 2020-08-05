// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

namespace WebSharper.Google.Visualization

open Microsoft.FSharp.Quotations
open WebSharper
open WebSharper.JavaScript
open WebSharper.Google.Visualization
open WebSharper.Google.Visualization.Base

[<RequireQualifiedAccess>]
type QuerySendMethod =
    /// Send the query using XmlHttpRequest.
    | [<Constant "xhr">] Xhr
    /// Send the query using script injection.
    | [<Constant "scriptInjection">] ScriptInjection
    ///  [Available only for gadgets] Send the query using the Gadget API  makeRequest() method. If specified, you should also specify makeRequestParams.
    | [<Constant "makeRequest">] MakeRequest
    /// Use the method specified by the tqrt URL parameter from the data source URL. tqrt can have the following values: 'xhr', 'scriptInjection', or 'makeRequest'. If tqrt is missing or has an invalid value, the default is 'xhr' for same-domain requests and 'scriptInjection' for cross-domain requests.
    | [<Constant "auto">] Auto

type QueryOptions [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable private sendMethod : QuerySendMethod
    [<DefaultValue>]
    val mutable private makeRequestParams : obj

type QueryErrorReason =
    /// The user does not have permissions to access the data source.
    | [<Constant "access_denied">] AccessDenied
    /// The specified query has a syntax error.
    | [<Constant "invalid_query">] InvalidQuery
    /// One or more data rows that match the query selection were not returned due to output size limits. (warning).
    | [<Constant "data_truncated">] DataTruncated
    /// The query did not respond within the expected time.
    | [<Constant "timeout">] Timeout

[<Name "google.visualization.QueryResponse">]
type QueryResponse =

    /// Returns the data table as returned by the data source. Returns null if the query execution failed and no data was returned.
    [<Stub>]
    member this.getDataTable() = X<DataTable>

    /// Returns a detailed error message for queries that failed. If the query execution was successful, this method returns an empty string. The message returned is a message that is intended for developers, and may contain technical information, for example 'Column {salary} does not exist'.
    [<Stub>]
    member this.getDetailedMessage() = X<string>

    /// Returns a short error message for queries that failed. If the query execution was successful, this method returns an empty string. The message returned is a short message that is intended for end users, for example 'Invalid Query' or 'Access Denied'.
    [<Stub>]
    member this.getMessages() = X<string>

    /// Returns an array of zero of more entries. Each entry is a short string with an error or warning code that was raised while executing the query.
    [<Stub>]
    member this.getReasons() = X<QueryErrorReason[]>

    /// Returns true if the query execution has any warning messages.
    [<Stub>]
    member this.hasWarning() = X<bool>

    /// Returns true if the query execution failed, and the response does not contain any data table. Returns <false> if the query execution was successful and the response contains a data table.
    [<Stub>]
    member this.isError() = X<bool>

/// Represents a query that is sent to a data source.
[<Name "google.visualization.Query">]
[<Require(typeof<Dependencies.GoogleCharts>)>]
type Query =

    /// <param name="dataSourceUrl">
    /// [Required, String] URL to send the query to. The data source should expose this URL in some way; for example, to get the dataSourceUrl from a Google Spreadsheet, do the following:
    ///     1. In your spreadsheet, select the range of cells.
    ///     2. Select 'Insert' and then 'Gadget' from the menu.
    ///     3. Open the gadget's menu by clicking on the top-right selector.
    ///     4. Select menu option 'Get data source URL'.
    /// </param>
    /// <param name="options">
    /// [Optional, Object] A map of options for the request. Note: If you are accessing a restricted data source, you should not use this parameter.
    /// </param>
    [<Stub>]
    new (dataSourceUrl: string, options: QueryOptions) = {}
    /// <param name="dataSourceUrl">
    /// [Required, String] URL to send the query to. The data source should expose this URL in some way; for example, to get the dataSourceUrl from a Google Spreadsheet, do the following:
    ///     1. In your spreadsheet, select the range of cells.
    ///     2. Select 'Insert' and then 'Gadget' from the menu.
    ///     3. Open the gadget's menu by clicking on the top-right selector.
    ///     4. Select menu option 'Get data source URL'.
    /// </param>
    [<Stub>]
    new (dataSourceUrl: string) = {}

    /// Stops the automated query sending that was started with setRefreshInterval().
    [<Stub>]
    member this.abort() = X<unit>

    /// Sets the query to automatically call the send method every specified duration (number of seconds), starting from the first explicit call to send. seconds is a number greater than or equal to zero.
    /// If you use this method, you should call it before calling the send method.
    /// Cancel this method either by calling it again with zero (the default), or by calling abort().
    [<Stub>]
    member this.setRefreshInterval(seconds: int) = X<unit>

    /// Sets the number of seconds to wait for the data source to respond before raising a timeout error. seconds is a number greater than zero. 
    /// The default timeout is 30 seconds. This method, if used, should be called before calling the send method.
    [<Stub>]
    member this.setTimeout(seconds: int) = X<unit>

    /// Sets the query string. The value of the string parameter should be a valid query. 
    /// This method, if used, should be called before calling the send method. Learn more about the Query language at https://developers.google.com/chart/interactive/docs/querylanguage
    [<Stub>]
    member this.setQuery(query: string) = X<unit>

    /// Sends the query to the data source. callback should be a function that will be called when the data source responds.
    [<Stub>]
    member this.send(callback: QueryResponse -> unit) = X<unit>
