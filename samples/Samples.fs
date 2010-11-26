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

// Most of the samples are taken from Google's playground
// And the examples in the visualization gallery.
// http://code.google.com/apis/visualization/documentation/gallery.html

namespace IntelliFactory.WebSharper.Google.Visualization.Samples

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base
open IntelliFactory.WebSharper.EcmaScript

type Color = Visualizations.Color

module Util =
    open IntelliFactory.WebSharper
    [<Inline "alert($msg)">]
    let Alert (msg: obj) : unit = X
    [<Inline "google.setOnLoadCallback($x)">]
    let OnLoad (x: unit -> unit) : unit = X

module Data =

    [<JavaScript>]
    let V: obj -> Cell = Cell.Value

    [<JavaScript>]
    let TableData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Name") |> ignore
        data.addColumn(NumberType, "Height") |> ignore
        data.addColumn(BooleanType, "Smokes") |> ignore
        data.addRows(3) |> ignore
        data.setCell(0, 0, "Tong Ning mu") |> ignore
        data.setCell(1, 0, "Huang Ang fa") |> ignore
        data.setCell(2, 0, "Teng nu") |> ignore
        data.setCell(0, 1, 174.) |> ignore
        data.setCell(1, 1, 523.) |> ignore
        data.setCell(2, 1, 86.) |> ignore
        data.setCell(0, 2, true) |> ignore
        data.setCell(1, 2, false) |> ignore
        data.setCell(2, 2, true) |> ignore
        data

    [<JavaScript>]
    let Views () =
        let views = [| for i in 1..7
                        -> new DataView(TableData ())|]

        views.[1].hideColumns [|1; 2|]
        views.[2].hideRows    [|0; 2|]
        views.[3].setColumns  [|1; 1|]
        views.[4].setRows     [|0; 2|]

        let simpleOrder = views.[5].getSortedRows(1)
        views.[5].setRows     simpleOrder

        let complexOrder =
            let by i b = SortType.By(i, b)
            views.[6].getSortedRows([| by 2 false; by 0 true|])
        views.[6].setRows    complexOrder


        views

    [<JavaScript>]
    let ATLData () =
        let data = new Base.DataTable()
        data.addColumn(DateType, "Name") |> ignore
        data.addColumn(NumberType, "Sold pencils") |> ignore
        data.addColumn(StringType, "Title") |> ignore
        data.addRows(6) |> ignore

        data.setCell(0, 0, new Date(2008, 1 ,1)) |> ignore
        data.setCell(1, 0, new Date(2008, 1 ,2)) |> ignore
        data.setCell(2, 0, new Date(2008, 1 ,3)) |> ignore
        data.setCell(3, 0, new Date(2008, 1 ,4)) |> ignore
        data.setCell(4, 0, new Date(2008, 1 ,5)) |> ignore
        data.setCell(5, 0, new Date(2008, 1 ,6)) |> ignore

        data.setCell(0, 1, 30000.) |> ignore
        data.setCell(1, 1, 14045.) |> ignore
        data.setCell(2, 1, 55022.) |> ignore
        data.setCell(3, 1, 75284.) |> ignore
        data.setCell(4, 1, 41476.) |> ignore
        data.setCell(5, 1, 33322.) |> ignore
        data.setCell(3, 2, "Bought pencils") |> ignore
        data

    [<JavaScript>]
    let AreaChartData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Year") |> ignore
        data.addColumn(NumberType, "Sales") |> ignore
        data.addColumn(NumberType, "Expenses") |> ignore
        data.addRows(4) |> ignore
        data.setValue(0, 0, "2004")
        data.setValue(0, 1, 1000)
        data.setValue(0, 2, 400)
        data.setValue(1, 0, "2005")
        data.setValue(1, 1, 1170)
        data.setValue(1, 2, 460)
        data.setValue(2, 0, "2006")
        data.setValue(2, 1, 660)
        data.setValue(2, 2, 1120)
        data.setValue(3, 0, "2007")
        data.setValue(3, 1, 1030)
        data.setValue(3, 2, 540)
        data

    [<JavaScript>]
    let GaugeData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Label") |> ignore
        data.addColumn(NumberType, "Value") |> ignore
        data.addRows(3) |> ignore
        data.setValue(0, 0, "Memory")
        data.setValue(0, 1, 80.)
        data.setValue(1, 0, "CPU")
        data.setValue(1, 1, 55.)
        data.setValue(2, 0, "Network")
        data.setValue(2, 1, 68.)
        data

    [<JavaScript>]
    let DateFormatData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Employee Name") |> ignore
        data.addColumn(DateType, "Start Date (Long)") |> ignore
        data.addColumn(DateType, "Start Date (Medium)") |> ignore
        data.addColumn(DateType, "Start Date (Short)") |> ignore
        data.addRows(3) |> ignore

        data.setValue(0, 0, "Mike")
        data.setValue(1, 0, "Bob")
        data.setValue(2, 0, "Alice")

        data.setValue(0, 1, new Date(2008, 1, 28, 0, 31, 26))
        data.setValue(0, 2, new Date(2008, 1, 28, 0, 31, 26))
        data.setValue(0, 3, new Date(2008, 1, 28, 0, 31, 26))

        data.setValue(1, 1, new Date(2007, 5, 1, 0))
        data.setValue(1, 2, new Date(2007, 5, 1, 0))
        data.setValue(1, 3, new Date(2007, 5, 1, 0))

        data.setValue(2, 1, new Date(2006, 7, 16))
        data.setValue(2, 2, new Date(2006, 7, 16))
        data.setValue(2, 3, new Date(2006, 7, 16))

        // Create three formatters in three styles.
        let optionsWith (s: string) = {Formatters.DateFormatOptions.Default with formatType = s}
        let formatterLong = new Formatters.DateFormat(optionsWith "long")
        let formatterMedium = new Formatters.DateFormat(optionsWith "medium")
        let formatterShort = new Formatters.DateFormat(optionsWith "short")

        // Reformat our data.
        formatterLong.format(data, 1);
        formatterMedium.format(data,2);
        formatterShort.format(data, 3);
        data

    [<JavaScript>]
    let GeoMapData () =
        let data = new Base.DataTable()
        data.addRows(6) |> ignore
        data.addColumn(StringType, "Country") |> ignore
        data.addColumn(NumberType, "Popularity") |> ignore
        data.setValue(0, 0, "Germany")
        data.setValue(0, 1, 200)
        data.setValue(1, 0, "United States")
        data.setValue(1, 1, 300)
        data.setValue(2, 0, "Brazil")
        data.setValue(2, 1, 400)
        data.setValue(3, 0, "Canada")
        data.setValue(3, 1, 500)
        data.setValue(4, 0, "France")
        data.setValue(4, 1, 600)
        data.setValue(5, 0, "RU")
        data.setValue(5, 1, 700)
        data

    [<JavaScript>]
    let GeoMapMarkersData () =
        let data = new Base.DataTable()
        data.addRows(6) |> ignore
        data.addColumn(StringType, "City") |> ignore
        data.addColumn(NumberType, "Popularity") |> ignore
        data.setValue(0, 0, "New York")
        data.setValue(0, 1, 200)
        data.setValue(1, 0, "Boston")
        data.setValue(1, 1, 300)
        data.setValue(2, 0, "Miami")
        data.setValue(2, 1, 400)
        data.setValue(3, 0, "Chicago")
        data.setValue(3, 1, 500)
        data.setValue(4, 0, "Los Angeles")
        data.setValue(4, 1, 600)
        data.setValue(5, 0, "Houston")
        data.setValue(5, 1, 700)
        data

    [<JavaScript>]
    let IntensityMapData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "", "Country") |> ignore
        data.addColumn(NumberType, "Population (mil)", "a") |> ignore
        data.addColumn(NumberType, "Area (km2)", "b") |> ignore
        data.addRows(5) |> ignore
        data.setValue(0, 0, "CN")
        data.setValue(0, 1, 1324)
        data.setValue(0, 2, 9640821)
        data.setValue(1, 0, "IN")
        data.setValue(1, 1, 1133)
        data.setValue(1, 2, 3287263)
        data.setValue(2, 0, "US")
        data.setValue(2, 1, 304)
        data.setValue(2, 2, 9629091)
        data.setValue(3, 0, "ID")
        data.setValue(3, 1, 232)
        data.setValue(3, 2, 1904569)
        data.setValue(4, 0, "BR")
        data.setValue(4, 1, 187)
        data.setValue(4, 2, 8514877)
        data

    [<JavaScript>]
    let MotionChartData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Fruit") |> ignore
        data.addColumn(DateType, "Date") |> ignore
        data.addColumn(NumberType, "Sales") |> ignore
        data.addColumn(NumberType, "Expenses") |> ignore
        data.addColumn(StringType, "Location") |> ignore
        data.addRows([|
                      [| V "Apples" ; V (new Date (1988, 0, 1)); V 1000; V 300; V "East"|]
                      [| V "Oranges"; V (new Date (1988, 0, 1)); V 1150; V 200; V "West"|]
                      [| V "Bananas"; V (new Date (1988, 0, 1)); V 300;  V 250; V "West"|]
                      [| V "Apples" ; V (new Date (1989, 6, 1)); V 1200; V 400; V "East"|]
                      [| V "Oranges"; V (new Date (1989, 6, 1)); V 750;  V 150; V "West"|]
                      [| V "Bananas"; V (new Date (1989, 6, 1)); V 788;  V 617; V "West"|] |])
        |> ignore
        data

    [<JavaScript>]
    let BlogMotionChartData () =
        let arrayData = [|
            ("Colombia",1950,12000)
            ("Colombia",1955,13828)
            ("Colombia",1960,16006)
            ("Ukraine",1995,51063)
            ("Ukraine",2000,48870)
            ("Ukraine",2005,46936) |] |> Array.toSeq
        let data = new Base.DataTable()
        data.addColumn(StringType, "Country") |> ignore
        data.addColumn(NumberType, "Year")      |> ignore
        data.addColumn(NumberType, "Population")   |> ignore
        for (c, y, p) in arrayData do
            data.addRow [|V c; V y; V p|] |> ignore
        data

    [<JavaScript>]
    let PieChartData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Task") |> ignore
        data.addColumn(NumberType, "Hours per Day") |> ignore
        data.addRows(5) |> ignore
        data.setValue(0, 0, "Work")
        data.setValue(0, 1, 11)
        data.setValue(1, 0, "Eat")
        data.setValue(1, 1, 2)
        data.setValue(2, 0, "Commute")
        data.setValue(2, 1, 2)
        data.setValue(3, 0, "Watch TV")
        data.setValue(3, 1, 2)
        data.setValue(4, 0, "Sleep")
        data.setValue(4, 1, 7)
        data

    [<JavaScript>]
    let OrgChartData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Name") |> ignore
        data.addColumn(StringType, "Manager") |> ignore
        data.addColumn(StringType, "ToolTip") |> ignore
        data.addRows(
            [|
              [| {Cell.Empty with v="Mike"; f="Mike<div style=\"color:red; font-style:italic\">President</div>"}; V ""; V "The President"|]
              [| {Cell.Empty with v="Jim"; f="Jim<div style=\"color:red; font-style:italic\">Vice President<div>"}; V "Mike"; V "VP"|]
              [| V "Alice"; V "Mike"; V ""|]
              [| V "Bob";   V "Jim";  V "Bob Sponge"|]
              [| V "Carol"; V "Bob";  V "" |] |]) |> ignore
        data

    [<JavaScript>]
    let ScatterData () =
        let data = new Base.DataTable()
        data.addColumn(NumberType, "Age") |> ignore
        data.addColumn(NumberType, "Weight") |> ignore
        data.addRows(6) |> ignore
        data.setValue(0, 0, 8)
        data.setValue(0, 1, 12)
        data.setValue(1, 0, 4)
        data.setValue(1, 1, 5.5)
        data.setValue(2, 0, 11)
        data.setValue(2, 1, 14)
        data.setValue(3, 0, 4)
        data.setValue(3, 1, 5)
        data.setValue(4, 0, 3)
        data.setValue(4, 1, 3.5)
        data.setValue(5, 0, 6.5)
        data.setValue(5, 1, 7)
        data

    [<JavaScript>]
    let FormatData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Department") |> ignore
        data.addColumn(NumberType, "Revenues Change") |> ignore
        data.addRows(
            [|
                [|V "Shoes"; { Cell.Empty with v = 12; f = "12.0%"}|]
                [|V "Sports"; { Cell.Empty with v = -7.3; f = "-7.3%"}|]
                [|V "Toys"; { Cell.Empty with v = 0; f = "0%"}|]
                [|V "Electronics"; { Cell.Empty with v = -2.1; f = "-2.1%"}|]
                [|V "Food"; { Cell.Empty with v = 22; f = "22.0%"} |] |]) |> ignore
        data

    [<JavaScript>]
    let NumberFormatData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Department") |> ignore
        data.addColumn(NumberType, "Revenues") |> ignore
        data.addRows([|
                        [| V "Shoes"; V 10700 |]
                        [| V "Sports"; V -15400 |]
                        [| V "Toys"; V 12500 |]
                        [| V "Electronics"; V -2100 |]
                        [| V "Food"; V 22600 |]
                        [| V "Art"; V 1100 |] |]) |> ignore

        let options =
            new Formatters.NumberFormatOptions(prefix = "$",
                                               negativeColor = "red",
                                               negativeParens = true)
        let formatter = new Formatters.NumberFormat(options)
        formatter.format(data, 1)
        data

    [<JavaScript>]
    let PatternFormatData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Name") |> ignore
        data.addColumn(StringType, "Email") |> ignore
        data.addRows([|
                        [|V "John Lennon"; V "john@beatles.co.uk"      |]
                        [|V "Paul McCartney"; V "paul@beatles.co.uk"   |]
                        [|V "George Harrison"; V "george@beatles.co.uk"|]
                        [|V "Ringo Starr"; V "ringo@beatles.co.uk"     |] |]) |> ignore
        let formatter = new Formatters.PatternFormat("<a href=\"mailto:{1}\">{0}</a>")
        formatter.format(data, [| 0; 1 |]); // Apply formatter and set the formatted value of the first column.
        let view = new Base.DataView(data)
        view.setColumns [|0|]
        view

    
    [<JavaScript>]
    let TreeMapData () =
        let data = new Base.DataTable()
        data.addColumn(StringType, "Region") |> ignore
        data.addColumn(StringType, "Parent") |> ignore
        data.addColumn(NumberType, "Market trade volume (size)") |> ignore
        data.addColumn(NumberType, "Market increase/decrease (color)") |> ignore
        data.addRows(
          [|
            [| V "Global"; V null; V 0; V 0 |];
            [| V "America"; V "Global"; V 0; V 0 |];
            [| V "Europe"; V "Global"; V 0; V 0 |];
            [| V "Asia"; V "Global"; V 0; V 0 |];
            [| V "Australia"; V "Global"; V 0; V 0 |];
            [| V "Africa"; V "Global"; V 0; V 0 |];
            [| V "Brazil"; V "America"; V 11; V 10 |];
            [| V "USA"; V "America"; V 52; V 31 |];
            [| V "Mexico"; V "America"; V 24; V 12 |];
            [| V "Canada"; V "America"; V 16; V -23 |];
            [| V "France"; V "Europe"; V 42; V -11 |];
            [| V "Germany"; V "Europe"; V 31; V -2 |];
            [| V "Sweden"; V "Europe"; V 22; V -13 |];
            [| V "Italy"; V "Europe"; V 17; V 4 |];
            [| V "UK"; V "Europe"; V 21; V -5 |];
            [| V "China"; V "Asia"; V 36; V 4 |];
            [| V "Japan"; V "Asia"; V 20; V -12 |];
            [| V "India"; V "Asia"; V 40; V 63 |];
            [| V "Laos"; V "Asia"; V 4; V 34 |];
            [| V "Mongolia"; V "Asia"; V 1; V -5 |];
            [| V "Israel"; V "Asia"; V 12; V 24 |];
            [| V "Iran"; V "Asia"; V 18; V 13 |];
            [| V "Pakistan"; V "Asia"; V 11; V -52 |];
            [| V "Egypt"; V "Africa"; V 21; V 0 |];
            [| V "S. Africa"; V "Africa"; V 30; V 43 |];
            [| V "Sudan"; V "Africa"; V 12; V 2 |];
            [| V "Congo"; V "Africa"; V 10; V 12 |] |]) |> ignore
        data

module SamplesInternals =
    open Data

    [<JavaScript>]
    let FormatDataWith (formatter : Formatters.Formatter) =
        let copy = FormatData().clone()
        formatter.format(copy, 1)
        copy

    /// Test for the Area Chart Events
    [<JavaScript>]
    let AreaChartEvents () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.AreaChart(container.Body)
            let options = {Visualizations.AreaChartOptions.Default
                                with width = 400.
                                     height = 240.
                                     legend = Visualizations.Bottom
                                     title = "Company Performance"}
            let event = Google.Visualization.Events.AreaChart.OnMouseOver visualization
            event.Add (fun args ->
                Util.Alert(string args.column + ", " + string args.row))
            visualization.draw(AreaChartData (), options))


    /// Test for NumberFormat
    [<JavaScript>]
    let PatternFormat () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.Table(container.Body)
            let options =
                {Visualizations.TableOptions.Default with
                    allowHtml = true
                    showRowNumber = true }
            visualization.draw(PatternFormatData (), options))


    /// Test for NumberFormat
    [<JavaScript>]
    let NumberFormat () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.Table(container.Body)
            let options =
                {Visualizations.TableOptions.Default with
                    allowHtml = true
                    showRowNumber = true}
            visualization.draw(NumberFormatData (), options))

    [<JavaScript>]
    let DateFormat () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.Table(container.Body)
            let options =
                {Visualizations.TableOptions.Default with
                    allowHtml = true
                    showRowNumber = true }
            visualization.draw(DateFormatData (), options))

    [<JavaScript>]
    let ColorFormat () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.Table(container.Body)
            let options =
                {Visualizations.TableOptions.Default with
                    allowHtml = true
                    showRowNumber = true }
            let colorFormat= new Formatters.ColorFormat()
            colorFormat.addRange(-20000, 0, "white", "orange")
            colorFormat.addRange(20000, null, "red", "#33ff33")
            visualization.draw(FormatDataWith colorFormat, options))

    [<JavaScript>]
    let BarFormat () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.Table(container.Body)
            let options =
                {Visualizations.TableOptions.Default with
                    allowHtml = true
                    showRowNumber = true }
            let barFormat = new Formatters.BarFormat({Formatters.BarFormatOptions.Default with base' = 22.})
            visualization.draw(FormatDataWith barFormat, options))

    [<JavaScript>]
    let ArrowFormat () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.Table(container.Body)
            let options =
                {Visualizations.TableOptions.Default with
                    allowHtml = true
                    showRowNumber = true }
            let arrowFormat = new Formatters.ArrowFormat(Formatters.ArrowFormatOptions.Base 22.)
            visualization.draw(FormatDataWith arrowFormat, options))

    [<JavaScript>]
    let OrgChart () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.OrgChart(container.Body)
            let options = {Visualizations.OrgChartOptions.Default
                            with allowHtml = true}
            visualization.draw(OrgChartData (), options);)

    [<JavaScript>]
    let ScatterChart () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.ScatterChart(container.Body)
            let vAxis = new Axis()
            let hAxis = new Axis()
            vAxis.title <- "Weight"
            hAxis.title <- "Age"
            let options = {Visualizations.ScatterChartOptions.Default
                            with width = 400.
                                 height = 240.
                                 pointSize = 5.
                                 legend = Visualizations.None
                                 hAxis = hAxis
                                 vAxis = vAxis}
            visualization.draw(ScatterData (), options))

    [<JavaScript>]
    let PieChart () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.PieChart(container.Body)
            let options = {Visualizations.PieChartOptions.Default
                                with width = 400.
                                     height = 240.
                                     is3D = true
                                     title = "My Daily Activities"}
            visualization.draw(PieChartData (), options))


    [<JavaScript>]
    let MotionChart () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.MotionChart(container.Body)
            let options = {Visualizations.MotionChartOptions.Default
                                with width = 600.
                                     height = 300.}
            visualization.draw(MotionChartData (), options))

    [<JavaScript>]
    let BlogMotionChart () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.MotionChart(container.Body)
            let options = {Visualizations.MotionChartOptions.Default
                                with width = 600.
                                     height = 300.}
            visualization.draw(BlogMotionChartData (), options))

    [<JavaScript>]
    let IntensityMap () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.IntensityMap(container.Body)
            visualization.draw(IntensityMapData (), Visualizations.IntensityMapOptions.Default))

    [<JavaScript>]
    let GeoMapMarkers () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.GeoMap(container.Body)
            let options = {Visualizations.GeoMapOptions.Default
                                with region = Visualizations.Countries.Alpha2Codes.US
                                     colors = [|0xFF8747; 0xFFB581; 0xc06000|] // orange colors
                                     dataMode = Visualizations.Markers
                          }
            visualization.draw(GeoMapMarkersData (), options))

    [<JavaScript>]
    let GeoMap () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.GeoMap(container.Body)
            visualization.draw(GeoMapData (), Visualizations.GeoMapOptions.Default))

    [<JavaScript>]
    let ColumnChart () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.ColumnChart(container.Body)
            let options = {Visualizations.ColumnChartOptions.Default
                                with width = 400.
                                     height = 240.
                                     legend = Visualizations.Bottom
                                     title = "Company Performance"}
            visualization.draw(AreaChartData (), options))

    [<JavaScript>]
    let LineChart () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.LineChart(container.Body)
            let options = {Visualizations.LineChartOptions.Default
                                with width = 400.
                                     height = 240.
                                     legend = Visualizations.Bottom
                                     title = "Company Performance"}
            visualization.draw(AreaChartData (), options))


    [<JavaScript>]
    let BarChart () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.BarChart(container.Body)
            let options = {Visualizations.BarChartOptions.Default
                                with width = 400.
                                     height = 240.
                                     legend = Visualizations.Bottom
                                     title = "Company Performance"}
            visualization.draw(AreaChartData (), options))

    [<JavaScript>]
    let Gauge () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.Gauge(container.Body)
            let options = {Visualizations.GaugeOptions.Default
                                with width = 400.
                                     height = 120.
                                     redFrom = 90.
                                     redTo = 100.
                                     yellowFrom = 75.
                                     yellowTo = 90.
                                     minorTicks = 5.}
            visualization.draw(GaugeData (), options))

    [<JavaScript>]
    let AreaChart () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.AreaChart(container.Body)
            let options = {Visualizations.AreaChartOptions.Default
                                with width = 400.
                                     height = 240.
                                     legend = Visualizations.Bottom
                                     title = "Company Performance"}
            visualization.draw(AreaChartData (), options))


    [<JavaScript>]
    let ColorObject () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.AreaChart(container.Body)
            let options = {Visualizations.AreaChartOptions.Default
                                with width = 400.
                                     height = 240.
                                     legend = Visualizations.Bottom
                                     backgroundColor = Color.HtmlColor "#000000"
                                     // FIXME: legendBackgroundColor = Color.FromProperties "black" "pink" 5
                                     title = "Company Performance"}
            visualization.draw(AreaChartData (), options))

    [<JavaScript>]
    let AnnotatedTimeLine () =
        Div [Attr.Style "width:700px; height:240px;"]
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.AnnotatedTimeLine(container.Body)
            visualization.draw(ATLData (), Visualizations.AnnotatedTimeLineOptions.Default))

    [<JavaScript>]
    let TableExample () =
        Div []
        |>! OnAfterRender(fun container ->
            let visualization = new Visualizations.Table(container.Body)
            visualization.draw(TableData (), Visualizations.TableOptions.Default))

    [<JavaScript>]
    let ViewExample () =
        Div ((Span [Text "Views Example"])
              :: [for view in Views ()
                   -> Div [Attr.Style "width:500px"]
                      |>! OnAfterRender (fun container ->
                            let visualization = new Visualizations.Table(container.Body)
                            visualization.draw(view, Visualizations.TableOptions.Default))])

    [<JavaScript>]
    let TableWithRowNumbers () =
        Div []
        |>! OnAfterRender (fun container ->
            let visualization = new Visualizations.Table(container.Body)
            let options = {Visualizations.TableOptions.Default with showRowNumber = true}
            visualization.draw(TableData (), options))

    [<JavaScript>]
    let TreeMap () =
        // The width and height MUST be declared using the style tag!
        Div [Attr.Id "myTreeMap"; Attr.Style "width: 1100px; height: 500px;"]
        |>! OnAfterRender (fun container ->
            
            let visualization = new Visualizations.TreeMap(container.Body)
            let options = new Visualizations.TreeMapOptions()
            options.minColor <- "#f00"
            options.midColor <- "#ddd"
            options.fontColor <- "black"
            options.showScale <- true
            options.headerHeight <- 15
            visualization.draw(TreeMapData (), options))

open SamplesInternals

type Samples() =
    inherit Web.Control()

    [<JavaScript>]
    override this.Body =
        Div [
             H1 [Text "Google Viz Samples"]
             TreeMap ()
             AreaChartEvents ()
             ArrowFormat ()
             BarFormat ()
             ColorFormat ()
             DateFormat ()
             NumberFormat ()
             PatternFormat ()
             OrgChart ()
             ScatterChart ()
             PieChart ()
             MotionChart ()
             BlogMotionChart ()
             IntensityMap ()
             LineChart ()
             GeoMap ()
             GeoMapMarkers ()
             ColumnChart ()
             BarChart ()
             AreaChart ()
             Gauge ()
             ColorObject ()
             AnnotatedTimeLine ()
             TableExample ()
             ViewExample ()
             TableWithRowNumbers ()

            ]
            |> fun x -> JQuery.JQuery.Of(x.Body).Children().Width(440).Ignore; x
            :> IPagelet

