# Etch.OrchardCore.ContextualEdit

Module for [Orchard Core](https://github.com/OrchardCMS/OrchardCore) that provides widget for displaying edit controls for the current page being viewed when user has permission to edit content.

## Build Status

[![Build Status](https://secure.travis-ci.org/etchuk/Etch.OrchardCore.ContextualEdit.png?branch=master)](http://travis-ci.org/etchuk/Etch.OrchardCore.ContextualEdit)

## Orchard Core Reference

This module is referencing the beta 3 build of Orchard Core ([`1.0.0-beta3-71077`](https://www.nuget.org/packages/OrchardCore.Module.Targets/1.0.0-beta3-71077)).

## Installing

[Download the source](https://github.com/etchuk/Etch.OrchardCore.ContextualEdit/archive/master.zip) or clone the repository to your local machine. Add the project to your solution that contains an Orchard Core project and add a reference to Etch.OrchardCore.ContextualEdit.

Once the module is in a usable state we'll make it available via NuGet.

## Usage

Enabling the "Contextual Edit" feature will create a new content type, "Contextual Edit" that is set to be a widget. Create a new "Contextual Edit" widget within a layer that either shows on every page or when user is authenticated. When viewing a content item, if you've got permission to edit the content you'll see an option to edit the content item being viewed.
