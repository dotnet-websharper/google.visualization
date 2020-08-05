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
    
    let private render (html: CR.HtmlTextWriter) (code: string) =
        html.AddAttribute("type", "text/javascript")
        html.RenderBeginTag "script"
        html.WriteLine code
        html.RenderEndTag()

    /// Some objects may be bound in other scripts before being initialized by the library
    [<Sealed>]
    type GoogleChartsDefineObjects() =
        interface R.IResource with
            member this.Render ctx =
                let code = "\
                    if(window.google===undefined) window.google=new Object(); \
                    if(google.visualization===undefined) google.visualization=new Object(); \
                    if(google.visualization.events===undefined) google.visualization.events=new Object();"
                fun html -> render (html CR.Scripts) code

    /// Requires the Google Charts API.
    [<Sealed>]
    [<Require(typeof<GoogleChartsDefineObjects>)>]
    type GoogleCharts() =
        inherit R.BaseResource("https://www.gstatic.com/charts/loader.js")

        //interface R.IResource with
        //    member this.Render ctx = fun writer ->
        //        let html = writer Core.Resources.RenderLocation.Scripts
        //        let src =
        //            String.concat "" [
        //                defaultArg (ctx.GetSetting "Google.Charts")
        //                    "https://www.gstatic.com/charts/loader.js"
        //                "?key="
        //                defaultArg (ctx.GetSetting "google.jsapi.key")
        //                    "your-key-here"
        //            ]
        //        html.AddAttribute("type", "text/javascript")
        //        html.AddAttribute("src", src)
        //        html.RenderBeginTag "script"
        //        html.RenderEndTag()

    [<AbstractClass>]
    type BaseResourceDefinition(package: string) =
        interface R.IResource with
            member this.Render ctx =
                let version =
                    ctx.GetSetting "Google.Charts.Version"
                    |> Option.defaultValue "45.2"
                let mapsApiKey =
                    if package = "geochart" then
                        ctx.GetSetting "Google.Maps.ApiKey"
                        |> Option.map (sprintf ",mapsApiKey:%s")
                        |> Option.defaultValue ""
                    else ""
                let code =
                    String.Format("google.charts.load(\"{0}\",\
                        {{packages:[\"{1}\"]{2}}});", version, package, mapsApiKey)
                fun html -> render (html CR.Scripts) code

    type internal B = BaseResourceDefinition

    [<Require(typeof<GoogleCharts>)>]
    type Table() =
        inherit B("table")

    [<Require(typeof<GoogleCharts>)>]
    type Timeline() =
        inherit B("timeline")
        
    [<Require(typeof<GoogleCharts>)>]
    type CoreChart() =
        inherit B("corechart")

    type AreaChart = CoreChart

    [<Require(typeof<GoogleCharts>)>]
    type Gauge() =
        inherit B("gauge")

    [<Require(typeof<GoogleCharts>)>]
    type GeoChart() =
        inherit B("geochart")

    [<Require(typeof<GoogleCharts>)>]
    type IntensityMap() =
        inherit B("intensitymap")

    [<Require(typeof<GoogleCharts>)>]
    type MotionChart() =
        inherit B("motionchart")

    [<Require(typeof<GoogleCharts>)>]
    type OrgChart() =
        inherit B("orgchart")

    [<Require(typeof<GoogleCharts>)>]
    type TreeMap() =
        inherit B("treemap")

    [<assembly:Require(typeof<GoogleCharts>)>]
    do ()

module GoogleCharts =
    open WebSharper
    open WebSharper.JavaScript

    [<Inline "google.charts.setOnLoadCallback($x)">]
    let OnLoad (x: unit -> unit) : unit = X
