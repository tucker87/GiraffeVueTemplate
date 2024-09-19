module VuePage

open Giraffe
open Giraffe.ViewEngine

let app (app: string) =
    [ div [ _id "app" ] []
      script
          []
          [ rawText
                $$"""
                            const options = {
                              moduleCache: {
                                vue: Vue
                              },
                              async getFile(url) {

                                const res = await fetch(url);
                                if ( !res.ok )
                                  throw Object.assign(new Error(res.statusText + ' ' + url), { res });
                                return {
                                  getContentData: asBinary => asBinary ? res.arrayBuffer() : res.text(),
                                }
                              },
                              addStyle(textContent) {

                                const style = Object.assign(document.createElement('style'), { textContent });
                                const ref = document.head.getElementsByTagName('style')[0] || null;
                                document.head.insertBefore(style, ref);
                              },
                            }

                            const { loadModule } = window['vue3-sfc-loader'];

                            const app = Vue.createApp({
                              components: {
                                'my-component': Vue.defineAsyncComponent( () => loadModule('{{app}}.vue', options) )
                              },
                              template: '<my-component></my-component>'
                            });

                            app.mount('#app');
                          """ ] ]

let RegisterVuePage (path: string) =
    let vueApp = app path |> Layout.layout
    let pageRoute = route path >=> htmlView vueApp
    Routing.addRoute pageRoute
