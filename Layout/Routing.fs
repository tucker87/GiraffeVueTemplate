module Routing

open Giraffe.Core
open System.Reflection

let mutable routes: HttpHandler list = []
let addRoute r = routes <- r :: routes

let RegisterPages =
    Assembly.GetEntryAssembly().GetTypes()
    |> Seq.map (fun t -> t.GetMethod "get_RegisterPage")
    |> Seq.filter (fun m -> m <> null)
    |> Seq.iter (fun method -> method.Invoke(null, null) |> ignore)
