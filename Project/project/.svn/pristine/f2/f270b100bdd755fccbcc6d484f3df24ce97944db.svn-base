require.config do
  baseUrl: '/scripts'
  paths:
    jquery: 'lib/jquery-1.11.3.min'
    underscore: 'lib/underscore-min'
    backbone: 'lib/backbone'
    template: 'lib/template'
    models: 'model/index'
    collections: 'collection/index'
    views: 'view/index'
  shim:
    underscore:
      exports: '_'
    backbone:
      deps: ['underscore', 'jquery']
      exports: 'Backbone'
    template:
      exports: 'template'

require ['jquery', 'underscore', 'backbone', 'models', 'collections', 'views', 'view/app_view', 'view/nav_view'], ($, _, backbone, Models, Collections, Views, App, NavView) ->
#  app = new App()
  nav = new NavView()


