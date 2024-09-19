module TestPage

open Giraffe

let path = "/TestPage"
let RegisterPage = VuePage.RegisterVuePage path

type User = { FirstName: string; }

Routing.addRoute (route (path + "/test") >=> json "testHandler Says Hi")
Routing.addRoute (route (path + "/amanda") >=> json { FirstName = "Amanda" })
