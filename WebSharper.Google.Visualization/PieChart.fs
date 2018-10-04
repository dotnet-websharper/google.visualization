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

module Enumerations =
    [<RequireQualifiedAccess>]
    type PieChartLegendPosition = 
        | [<Constant "right" >] Right
        | [<Constant "left" >]  Left
        | [<Constant "top" >]   Top
        | [<Constant "bottom" >] Bottom
        | [<Constant "none" >] None
        | [<Constant "label" >] Label

[<RequireQualifiedAccess>]
type PieSliceText =
    | [<Constant "percentage">] Percentage
    | [<Constant "value">] Value
    | [<Constant "label">] Label
    | [<Constant "none">] None

type PieSlice [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable color : string

    [<DefaultValue>]
    val mutable offset : float

    [<DefaultValue>]
    val mutable textStyle : TextStyle

type PieChartOptions [<Inline "{}">] () =
    inherit ChartOptionsCommon()

    [<DefaultValue>]
    val mutable is3D : bool

    [<DefaultValue>]
    val mutable pieHole : float

    [<DefaultValue>]
    val mutable pieSliceBorderColor : string

    [<DefaultValue>]
    val mutable pieSliceText : PieSliceText

    [<DefaultValue>]
    val mutable pieSliceTextStyle : TextStyle

    [<DefaultValue>]
    val mutable pieStartAngle : float

    [<DefaultValue>]
    val mutable pieResidueSliceColor : string

    [<DefaultValue>]
    val mutable pieResidueSliceLabel : string

    [<DefaultValue>]
    val mutable slices : PieSlice[]

    [<DefaultValue>]
    val mutable sliceVisibilityThreshold : float

/// A line chart that is rendered within the browser using SVG or VML. Displays 
/// tips when clicking on points. Animates lines when clicking on legend entries. 
[<Name "google.visualization.PieChart">]
[<Require(typeof<Dependencies.CoreChart>)>]
type PieChart [<Stub>] (elem: Dom.Element) =
    inherit ChartCommon<PieChartOptions> ()
