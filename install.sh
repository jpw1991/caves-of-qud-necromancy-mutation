#!/bin/bash
install_path="$HOME/.config/unity3d/Freehold Games/CavesOfQud/Mods"
folder_name=ChebsNecromancyMutation

dest="$install_path/$folder_name"

if [ ! -d "$dest" ]; then
    mkdir "$dest"
fi

cp -f NecromancyMutation/Mutations.xml "$dest"
cp -f NecromancyMutation/ChebGonaz_Reanimate.cs "$dest"
cp -f NecromancyMutation/manifest.json "$dest"
cp -f NecromancyMutation/preview.png "$dest"
cp -f NecromancyMutation/workshop.json "$dest"
cp -f NecromancyMutation/ObjectBlueprints.xml "$dest"

