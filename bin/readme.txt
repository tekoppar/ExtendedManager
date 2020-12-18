On start the extended manager reads the KeyRebindings.txt file to get what keys are bound to what inputs, multi binds are supported. So if you bind Movement Up/Ability1 to a key for sjump validating and have both of those keys it will still work. Currently the timing validating isn't supported with the janky slowdown, so if you try to validate something where it's used the timing can say you failed even when you didn't.

Right click to open the menu for the extendend options.

Settings: Save and reload the configuration. The save needs to be done for the program to write the updated data to the file. Until then changes are only kept in memory, reload is used if you manually edited the Combos.json file to update the changes.

Settings: Visiblity allows you to hide/show the default values in the manager

Open Teleport Menu:Will open up a new window with the current positions value filled in. Here you can change the values and click on teleport to teleport to those coordinates, cancel removes the window.

New validator: Creates a new empty validator.

After that the list is filled with the current validators.

--------

The first item under a validator menu is the name of the validator, this changes as you type.

Enabled: Determines if the validator should be validated towards the inputs.

Teleport: Will teleport you to the coordinates entered below, the coordinates are saved so you can use it to set a position where you want to train/validate your inputs and can then simply click on teleport to get there directly.

Show Frame Timings: Shows the timing in frames between 2 inputs. So if a validator has 2 inputs it will show the timing of frames you pressed between those.

Show MS Timings: Shows the timing in milliseconds between 2 inputs. So if a validator has 2 inputs it will show the timing of milliseconds you pressed between those.

Log Data: Logs the information shown to a file with the validators name.txt.

Show Frame Difference: Shows the timing in frames between 2 inputs compared to the closest timing. So if you had Ability1 then Jump with a timing of 15, if you pressed jump 10 frames after Ability1 it would show you a value of 5 meaning that you were 5 frames too early. Positive values means you're early while negative values means you're late.

Edit Keys: Opens up a new menu where you can add new inputs to the validator, each input can contain multiple keys and multiple timings. More then 1 key for an input means that both keys have to be hit in no specific order without timings, there's no support for OR keys currently and each key entered needs to be pressed before the validator continues to the next row of keys. Each input has a searchable dropdown of valid keys to choose from, click on the Add Input next to it to add the chosen key. To remove a key right click on the key. Each timing needs to be separated by the character , and there's currently no range support so something like 5-15 isn't valid. Remove input removes the input. Nothing is actually changed until you hit Ok to confirm the changes, hitting cancel will revert everything to how it was when you opened it.

Remove Validator: Will open up a popup asking if you're sure before removing the validator. A validator isn't completely removed until the configuration has been saved. So even if you accidentally removed one, as long as you don't save you can either restart or reload the configuration to get it back.

Edit Uberstates: Allows you to add uberstate changes so that when "Reset Uberstates and Teleport" is clicked the values added there will be changed. Certain uberstate values don't change by just setting their values, so it's best to click "Reset Uberstates and Teleport" and then hit a save and unload the area or kill Ori for all changes to properly effect the area. In the uberstate editor click on add uberstate to add a new uberstate, you can search for a ubergroup by typing it's name or use the dropdown menu, once a ubergroup has been chosen the uber id list will be populated with assosicated values and you can do the same there. The correct value will be displayed to edit. To remove a uberstate click remove. No changes are saved until the "Save" button is hit, "Cancel" aborts all changes made.

Reset Uberstates and Teleport: Resets the uberstates changes added and teleports you to the position set under teleport.