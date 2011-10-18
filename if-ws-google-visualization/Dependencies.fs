// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2010.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

namespace IntelliFactory.WebSharper.Google.JsApi

open System
open System.Configuration
open IntelliFactory.WebSharper

module R = IntelliFactory.WebSharper.Core.Resources

/// Requires the Google JS API.
[<Sealed>]
type JsApi() =
    interface R.IResource with
        member this.Render ctx html =
            let src =
                String.concat "" [
                    defaultArg (ctx.GetSetting "Google.JsAPI")
                        "http://www.google.com/jsapi"
                    "?key="
                    defaultArg (ctx.GetSetting "google.jsapi.key")
                        "your-key-here"
                ]
            html.AddAttribute("type", "text/javascript")
            html.AddAttribute("src", src)
            html.RenderBeginTag "script"
            html.RenderEndTag()

namespace IntelliFactory.WebSharper.Google.Visualization

module Dependencies =
    open System
    open System.Configuration
    open System.IO
    open IntelliFactory.WebSharper
    open IntelliFactory.WebSharper.Google.JsApi
    module R = IntelliFactory.WebSharper.Resources

    let private render (html: System.Web.UI.HtmlTextWriter) (code: string) =
        html.AddAttribute("type", "text/javascript")
        html.RenderBeginTag "script"
        html.WriteLine code
        html.RenderEndTag()

    [<Sealed>]
    type Visualization() =
        interface R.IResource with
            member this.Render ctx html =
                render html "google.load('visualization', '1');"

    [<AbstractClass>]
    type BaseResourceDefinition(package: string) =
        interface R.IResource with
            member this.Render ctx html =
                String.Format("google.load(\"visualization\",\
                    \"1\", {{packages:[\"{0}\"]}});", package)
                |> render html

    type internal B = BaseResourceDefinition

    [<Require(typeof<JsApi>)>]
    type Table() =
        inherit B("table")

    [<Require(typeof<JsApi>)>]
    type AnnotatedTimeLine() =
        inherit B("annotatedtimeline")

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
    type GeoMap() =
        inherit B("geomap")

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
