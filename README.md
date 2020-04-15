# ReUsableUIForUnity3D
A reusable framework that can enable quick prototyping of UI screens in Unity3D

[![](https://media.giphy.com/media/gHEwwK1ubjOoX0Rj26/giphy.gif)](https://youtu.be/DN2In2v0xIY)

## Need
While working on a Unity3D project, one of the challenge is desigining UI screens and then writing clean code that enables switching from one screen to another easy while developing.

## Pain Points
When creating a base framework the code should be written in such a way that if a designer or a junior developer takes up the project they do not make  code highly coupled which often happend and then a lot of code refactoring is required when a new feature is requested from the client.

## Solution
ReUsableUIForUnity3D framework enables the smooth transition among the screens created in Unity3D with no coding at all, just hook-up your UI with the scripts created and animations which are already there in the framework.
#### Implementation - https://youtu.be/kqSHcNE299I



## Extensibility
**Unity Events** are exposed which can be used to call the custom events  for example to trigger a particle effect or to play a sound on screen change.

The scripts are highly decoupled and written keeping **SOLID** principles in mind, therefore they can also extend the base classes to write your own implementation
