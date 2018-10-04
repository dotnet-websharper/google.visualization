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

module Dependencies =
    open System
    open System.Configuration
    open System.IO
    open WebSharper
    module R = WebSharper.Resources
    module CR = WebSharper.Core.Resources

    /// Requires the Google JS API.
    [<Sealed>]
    type JsApi() =
        inherit R.BaseResource("https://www.google.com/jsapi")
    //    interface R.IResource with
    //        member this.Render ctx html =
    //            let src =
    //                String.concat "" [
    //                    defaultArg (ctx.GetSetting "Google.JsAPI")
    //                        "http://www.google.com/jsapi"
    //                    "?key="
    //                    defaultArg (ctx.GetSetting "google.jsapi.key")
    //                        "your-key-here"
    //                ]
    //            html.AddAttribute("type", "text/javascript")
    //            html.AddAttribute("src", src)
    //            html.RenderBeginTag "script"
    //            html.RenderEndTag()

    let private render (html: CR.HtmlTextWriter) (code: string) =
        html.AddAttribute("type", "text/javascript")
        html.RenderBeginTag "script"
        html.WriteLine code
        html.RenderEndTag()

    [<Sealed>]
    type Visualization() =
        interface R.IResource with
            member this.Render ctx =
                fun html -> render (html CR.Scripts) "google.load('visualization', '1');"

    [<AbstractClass>]
    type BaseResourceDefinition(package: string) =
        interface R.IResource with
            member this.Render ctx =
                let code =
                    String.Format("google.load(\"visualization\",\
                        \"1\", {{packages:[\"{0}\"]}});", package)
                fun html -> render (html CR.Scripts) code

    type internal B = BaseResourceDefinition

    [<Require(typeof<JsApi>)>]
    type Table() =
        inherit B("table")

    [<Require(typeof<JsApi>)>]
    type Timeline() =
        inherit B("timeline")

    [<Require(typeof<JsApi>)>]
    type AreaChart() =
        inherit B("corechart")

    [<Require(typeof<JsApi>)>]
    type Gauge() =
        inherit B("gauge")

    [<Require(typeof<JsApi>)>]
    type CoreChart() =
        inherit B("corechart")

    [<Require(typeof<JsApi>)>]
    type GeoChart() =
        inherit B("geochart")

    [<Require(typeof<JsApi>)>]
    type IntensityMap() =
        inherit B("intensitymap")

    [<Require(typeof<JsApi>)>]
    type MotionChart() =
        inherit B("motionchart")

    [<Require(typeof<JsApi>)>]
    type OrgChart() =
        inherit B("orgchart")

    [<Require(typeof<JsApi>)>]
    type TreeMap() =
        inherit B("treemap")

    [<assembly:Require(typeof<JsApi>)>]
    do ()
