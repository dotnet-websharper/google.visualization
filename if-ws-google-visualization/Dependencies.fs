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

module R = IntelliFactory.WebSharper.Resources

/// Requires the Google JS API.
type JsApi() =
    static let resource : R.Resource =
        {
            Id              = "Google.JsAPI"
            Dependencies    = []
            Body            =
                R.ScriptBody (
                    R.ExternalLocation [
                        R.ConfigurablePart("Google.JsAPI",
                            "http://www.google.com/jsapi")
                        R.FixedPart "?key="
                        R.ConfigurablePart("google.jsapi.key",
                            "your-key-here")
                    ]
                )
        }

    static member Resource = resource

    interface Resources.IResourceDefinition with
        member this.Resource = resource

namespace IntelliFactory.WebSharper.Google.Visualization

module Dependencies =
    open System
    open System.Configuration
    open System.IO
    open IntelliFactory.WebSharper
    open IntelliFactory.WebSharper.Google.JsApi
    module R = IntelliFactory.WebSharper.Resources

    type Visualization() =
        interface Resources.IResourceDefinition with
            member this.Resource =
                {
                    Id = "Google.Visualization"
                    Dependencies = []
                    Body =
                        let code = "google.load('visualization', '1');"
                        R.CodeBody [R.FixedPart code]
                }

    [<AbstractClass>]
    type BaseResourceDefinition(id: string, package: string) =
        interface Resources.IResourceDefinition with
            member this.Resource =
                {
                    Id              = id
                    Dependencies    = [JsApi.Resource]
                    Body            =
                        let code =
                            String.Format("google.load(\"visualization\",\
                                \"1\", {{packages:[\"{0}\"]}});", package)
                        R.CodeBody [R.FixedPart code]
                }

    type internal B = BaseResourceDefinition

    type Table() =
        inherit B("Table", "table")

    type AnnotatedTimeLine() =
        inherit B("AnnotatedTimeLine", "annotatedtimeline")

    type AreaChart() =
        inherit B("AreaChart", "corechart")

    type Gauge() =
        inherit B("Gauge", "gauge")

    type CoreChart() =
        inherit B("CoreChart", "corechart")

    type GeoMap() =
        inherit B("GeoMap", "geomap")

    type IntensityMap() =
        inherit B("IntensityMap", "intensitymap")

    type MotionChart() =
        inherit B("MotionChart", "motionchart")

    type OrgChart() =
        inherit B("OrgChart", "orgchart")

    type TreeMap() =
        inherit B("TreeMap", "treemap")
