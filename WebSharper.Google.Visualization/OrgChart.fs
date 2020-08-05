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

type OrgChartSize =
    | [<Constant "small">] Small
    | [<Constant "medium">] Medium
    | [<Constant "large">] Large

type OrgChartOptions [<Inline "{}">] () =
    [<DefaultValue>]
    val mutable allowCollapse : bool

    [<DefaultValue>]
    val mutable allowHtml : bool

    [<DefaultValue>]
    val mutable color : string

    [<DefaultValue>]
    val mutable nodeClass : string

    [<DefaultValue>]
    val mutable selectedNodeClass : string

    [<DefaultValue>]
    val mutable selectionColor : string

    [<DefaultValue>]
    val mutable size : OrgChartSize

/// A line chart that is rendered within the browser using SVG or VML. Displays 
/// tips when clicking on points. Animates lines when clicking on legend entries. 
[<Name "google.visualization.OrgChart">]
[<Require(typeof<Dependencies.GoogleCharts>)>]
[<Require(typeof<Dependencies.OrgChart>)>]
type OrgChart =
    [<Stub>]
    new (elem: Dom.Element) = {}

    /// Draws the chart. You can speed up response time for the second and later calls to
    /// draw() by using the allowRedraw property.
    [<Stub>]
    member this.draw(data: DataCommon, options: OrgChartOptions) : unit = X

    /// Standard getSelection implementation. Selection elements are
    /// all row elements. Can return more than one selected row. The row
    /// indexes in the selection object refer to the original data table
    /// regardless of any user interaction (sort, paging, etc.).
    [<Stub>]
    member this.getSelection() : obj = X

    /// Collapses or expands the node.
    /// * row - Index of the row to expand or collapse.
    /// * collapsed Whether to collapse or expand the row, where true means collapse.
    [<Stub>]
    member this.collapse(row: float, collapsed: bool) : unit = X

    /// Standard setSelection() implementation, but can only select
    /// entire rows, or multiple rows. The row indexes in the selection
    /// object refer to the original data table regardless of any user
    /// interaction (sort, paging, etc.).
    [<Stub>]
    member this.setSelection(selection: obj) : unit = X

    /// Returns an array with the indexes of the children of the given node.
    [<Stub>]
    member this.getChildrenIndexes(row: float) : float [] = X

    /// Returns an array with the list of the collapsed node's indexes.
    [<Stub>]
    member this.getCollapsedNodes : float [] = X

