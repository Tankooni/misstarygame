# How to MetaData #

## General MetaData Layout

All metadata is saved as json files. These files are made of awesome. Please refrain from eating them until the end of the jam and pickles are a good nutritious meeal worms suck bonemeal is not made of bones; it's made of people drive cars go fast and furious tigers scare me.

Let's try that again.

All metadata is saved in json format. The base of the file should contain exactly 1 json object pertaining to the content it describes with key:value pairs to describe the object.

## Metadata File Types ##

### Master Metadata ###
There should be exactly 1 master metadata file for the project as a whole. It should define the following attributes:

- StartingScene (string, name of folder for scene)
- SpawnEntrance (string, name of entrance defined in the scene's metadata)

### Scene Metadata ###
This metadata is tied to a scene. It should define the following attributes:

- Name (string, name of scene)
- Background (string, path to background image, reletive to the scene's folder)
- Foreground (string, path to foreground image, reletive to the scene's folder)
- Collision (string, path to collision map, reletive to the scene's folder)
- Perspective (string, path to perspective map, reletive to the scene's folder)
- Objects (array of objects, entities in the scene)
    - Name (string, name of object (must exist in the entities folder))
    - Position (object, starting position of the object)
        - X
        - Y
    - DefaultAnimation (string, name of strarting animation. Must be an animation of the object)
    - Attributes (object, key:value pairs describing attributes for the in game object)
- Entrances (object, places a player can spawn in the scene)
    - Name (string): {"X": int, "Y", int}

### Object Metadata ###
This metadata should be tied to any entity. It should define the following attributes:

- Name (string)
- FrameSize (Object, size of one frame)
    - X (int, width of object)
    - Y (int, height of object)
- HotSpot (object, centered at the base of the object)
    - X (int, horizontal position)
    - Y (int, vertical position)
- Scaling (bool, true if it should be scaled in the scene)
- Animations (array of objects, must corrilate to an animation folder in the object's directory)
    - Name (string, name of animation)
    - FPS (int, speed of animation)
    - Frames (int, number of frames in the animation)
- Commands (array of objects, commands that appear in the command wheel)
    - Name (string, name of command)
    - Actions (array of objects, actions that are triggered when command is clicked)
        - Name (string, name of action, must exist)
        - Args (object, arguments for the action)
    - Sprite (string, name of sprite to use for command (this overrides the default sprite for the command), NOT IMPLEMENTED YET)
    - EventDependancies (array of strings, these events must be completed for this action to appear)
    - EventRestrictions (array of commands that prevent this command from appearing in the list)

### Event Metadata ###
Each event is in it's own json file named the name of the event. They can also be organized within folders so long as the folders reside within the events directory.

Json Layout:

- Name (string, eaten by the dark god)
- Actions (array of objects, actions that are triggered when the event is completed)
        - Name (string, name of action, must exist)
        - Args (object, arguments for the action)
- Dependancies (array of strings, events that must occur before this one can be completed)
- Restrictions (array of string, events that, if completed, prevent this from being completed)


## Actions ##
These are the availible actions:

### Dialog ###
Displays a text box and prevents the player from moving until it is finished.

Arguments:

- Text (string, what text to display)
- Speaker (string, name of the person/object speaking)
- SpeakerSprite (string, path to sprite for the speaker. Overrides the default, NOT IMPLEMENTED YET)

### AddObjectToInventory ###
Adds the given object to the player's inventory.

Arguments:

- RemoveParent (bool, if true, removes the parent object on pickup, defaults to true)
- ObjectPickedUp (string, name of object to add to inventory. Defaults to parent object)

### RemoveObjectFromInventory ###
Removes an object intance from the player's inventory.

Arguments:

- InstanceName (string, name of instance to remove)

### AddObjectToScene ###
Adds a new instance of an object to the current scene.

Arguments:

- ObjectName (string, name of object to create. Must exist)
- InstanceName (string, name of object instance. Cannot be a duplicate?)
- Position (object, X/Y position to place the object in the scene)
    - X (int)
    - Y (int)

### RemoveObjectFromScene ###
Removes a object instance from the current scene.

Arguments:

- InstanceName (string, name of instance to remove)

### Goto ###
Changes the current scene and places the player at the given entrance.

Arguments:

- SceneName (string, name of scene to move to. Must exist)
- EntranceName (string, name of entrance to spawn at. Must exist)

### CompleteEvent ###
Marks an event as completed.

Arguments:

- EventName (string, name of the event to complete)

## Folder structure ##
All assets should be defined in the follow structure, from the root content directory:

- events/
    - TBD
- music/
    - <All music files in .ogg format>
- objects/
    - <All game object folders>
        - MetaData.json
        - <Folders for each of the object's animations>
            - <Each frame of the animation named by number>
- scenes/
    - <All scene folders>
        - MetaData.json
        - <All files/folders used in the scene's metadata> 
- sounds/
    - <All sound effect files>
- UI/
    - <All folders for UI elements>
        - <All assets for the this UI element>
- MainConfig.json