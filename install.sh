#!/bin/bash
install_path="$HOME/.config/unity3d/Freehold Games/CavesOfQud/Mods"
folder_name=NecromancyMutation

dest="$install_path/$folder_name"

if [ ! -d "$dest" ]; then
    mkdir "$dest"
fi

cp -f NecromancyMutation/Mutations.xml "$dest"
cp -f NecromancyMutation/ChebGonaz_Reanimate.cs "$dest"
