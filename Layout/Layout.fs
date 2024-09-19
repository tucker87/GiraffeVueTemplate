module Layout

open Giraffe.ViewEngine

let layout (content: XmlNode list) =
    html
        []
        [ head
              []
              [ title [] [ encodedText "giraffeTest" ]
                link [ _rel "stylesheet"; _type "text/css"; _href "/main.css" ]
                script [ _src "https://unpkg.com/vue@3/dist/vue.global.js" ] []
                script [ _src "https://cdn.jsdelivr.net/npm/vue3-sfc-loader/dist/vue3-sfc-loader.js" ] [] ]
          body [] content ]
