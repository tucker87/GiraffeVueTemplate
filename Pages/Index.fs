module IndexPage

open Giraffe

type Message = { Text: string }

module Views =
    open Giraffe.ViewEngine

    let partial () = h1 [] [ encodedText "giraffeTest" ]

    let index (model: Message) =
        [ partial (); p [] [ encodedText model.Text ] ] |> Layout.layout


let indexHandler (name: string) =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model = { Text = greetings }
    let view = Views.index model
    htmlView view

let RegisterPage =
    Routing.addRoute (route "/" >=> indexHandler "world")
    Routing.addRoute (routef "/hello/%s" indexHandler)
