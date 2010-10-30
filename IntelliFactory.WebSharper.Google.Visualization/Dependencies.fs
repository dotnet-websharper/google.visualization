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

open System.Configuration
open IntelliFactory.WebSharper

/// Requires the Google JS API.
type JsApi() =
    interface IResource with
        member this.Id = "Google.JsAPI"
        member this.Dependencies = Seq.empty
        member this.Render (resolver) (writer) =
            match ConfigurationManager.AppSettings.["google.jsapi.key"] with
            | null ->
                failwith "AppSettings must contain `google.jsapi.key`."
            | key ->
                writer.Write("<script type='text/javascript' \
                    src='http://www.google.com/jsapi?key={0}'>\
                    <!----></script>", key)

namespace IntelliFactory.WebSharper.Google.Visualization

module Dependencies =
    open System.Configuration
    open System.IO
    open IntelliFactory.WebSharper
    open IntelliFactory.WebSharper.Google.JsApi    

    let private render (name: string) (writer: TextWriter) =
        writer.Write("<script type='text/javascript'>\
                        google.load('visualization', '1', {{packages:['{0}']}});\
                      </script>", name)

    type Visualization() =
        interface IResource with
            member this.Id = "Google.Visualization"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_) (writer) =
                writer.Write("<script type='text/javascript'>\
                                google.load('visualization', '1');\
                              </script>")

    type Table() =
        interface IResource with
            member this.Id = "Google.Visualization.Table"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_)(writer) = render "table" writer

    type AnnotatedTimeLine() = 
        interface IResource with
            member this.Id = "Google.Visualization.AnnotatedTimeLine"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_)(writer) = render "annotatedtimeline" writer

    type AreaChart() =
        interface IResource with
            member this.Id = "Google.Visualization.AreaChart"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton    
            member this.Render(_)(writer) = render "corechart" writer

    type Gauge() = 
        interface IResource with
            member this.Id = "Google.Visualization.Gauge"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_)(writer) = render "gauge" writer

    type CoreChart() =
        interface IResource with
            member this.Id = "Google.Visualization.CoreChart"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_)(writer) = render "corechart" writer

    type GeoMap() =
        interface IResource with
            member this.Id = "Google.Visualization.GeoMap"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_)(writer) = render "geomap" writer

    type IntensityMap() = 
        interface IResource with
            member this.Id = "Google.Visualization.IntensityMap"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_)(writer) = render "intensitymap" writer

    [<Require(typeof<JsApi>)>]
    type MotionChart() =
        interface IResource with
            member this.Id = "Google.Visualization.MotionChart"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_)(writer) = render "motionchart" writer

    [<Require(typeof<JsApi>)>]
    type OrgChart() = 
        interface IResource with
            member this.Id = "Google.Visualization.OrgChart"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_)(writer) = render "orgchart" writer

    [<Require(typeof<JsApi>)>]
    type TreeMap() = 
        interface IResource with
            member this.Id = "Google.Visualization.TreeMap"
            member this.Dependencies = JsApi () :> IResource |> Seq.singleton
            member this.Render(_)(writer) = render "treemap" writer
