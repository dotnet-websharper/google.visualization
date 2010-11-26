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

/// Requires the Google JS API.
type JsApi() =
    interface Resources.IResource with
        member this.Id = "Google.JsAPI"
        member this.Dependencies = Seq.empty
        member this.Render resolver =
            match ConfigurationManager.AppSettings.["google.jsapi.key"] with
            | null ->
                failwith "AppSettings must contain `google.jsapi.key`."
            | key ->
                String.Format("http://www.google.com/jsapi?key={0}", key)
                |> Resources.RenderJavaScript

namespace IntelliFactory.WebSharper.Google.Visualization

module Dependencies =
    open System
    open System.Configuration
    open System.IO
    open IntelliFactory.WebSharper
    open IntelliFactory.WebSharper.Google.JsApi   

    let private render (name: string) =
        [Markup.ElementNode {
            Name        = "script"
            Attributes  = [{Name = "type"; Value="text/javascript"}]
            Children    =
                [
                    String.Format("google.load(\"visualization\", \"1\", \
                        {{packages:[\"{0}\"]}});", name)
                    |> Markup.VerbatimTextNode
                ]
        }]

    type Visualization() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render resolver =
                [Markup.ElementNode {
                    Name        = "script"
                    Attributes  = [{Name = "type"; Value="text/javascript"}]
                    Children    =
                        [Markup.TextNode "google.load('visualization', '1')"]
                }]

    type Table() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.Table"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render resolver = render "table"

    type AnnotatedTimeLine() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.AnnotatedTimeLine"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render _ = render "annotatedtimeline"

    type AreaChart() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.AreaChart"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render _ = render "corechart"

    type Gauge() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.Gauge"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render _ = render "gauge"

    type CoreChart() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.CoreChart"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render _ = render "corechart"

    type GeoMap() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.GeoMap"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render _ = render "geomap"

    type IntensityMap() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.IntensityMap"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render _ = render "intensitymap"

    type MotionChart() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.MotionChart"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render _ = render "motionchart"

    type OrgChart() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.OrgChart"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render _ = render "orgchart"

    type TreeMap() =
        interface Resources.IResource with
            member this.Id = "Google.Visualization.TreeMap"
            member this.Dependencies = Seq.singleton (JsApi () :> _)
            member this.Render _= render "treemap"