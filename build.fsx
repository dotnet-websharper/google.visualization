#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.Google.Visualization", "2.5")
        .References(fun r -> [r.Assembly "System.Web"])

let main =
    bt.WebSharper.Library("IntelliFactory.WebSharper.Google.Visualization")
        .SourcesFromProject()

let test =
    bt.WebSharper.HtmlWebsite("IntelliFactory.WebSharper.Google.Visualization.Tests")
        .SourcesFromProject()
        .References(fun r -> [r.Project main])

bt.Solution [
    main
    test

    bt.NuGet.CreatePackage()
        .Description("WebSharper Extensions for Google Visualization")
        .Add(main)

]
|> bt.Dispatch
