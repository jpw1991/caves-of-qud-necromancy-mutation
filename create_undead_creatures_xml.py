
if __name__ == '__main__':
    creatures_considered = ["Templar", "Bat", "Pig", "Boar", "Cave Spider", "Ray Cat", "Croc", "Dog", "Electrofuge",
                            "Giant Beetle", "Giant Centipede", "GiantDragonfly", "Glowfish", "Goat", "Horned Chameleon",
                            "Qudzu", "Salamander", "Scorpiock", "Snapjaw", "Chute Crab", "Eyeless Crab", "Feral Lah",
                            "Girshling", "Glowmoth", "Knollworm", "Leech", "Salthopper", "Seedsprout Worm",
                            "Worm of the Earth", "Naphtaali", "BaseHindren", "Albino ape", "Barkbiter",
                            "Chitinous Puma", "Dawnglider", "Equimax", "Fire ant", "Fire Snout", "Ghost Perch",
                            "Ice frog", "Quillipede", "Rustacean", "Spark Tick", "Voider", "Goatfolk", "Electric Snail",
                            "Eyeless King Crab", "BaseBreather", "FireBreather", "IceBreather", "CorrosiveBreather",
                            "NormalityBreather", "PoisonBreather", "SleepBreather", "StunBreather", "ConfusionBreather",
                            "Troll", "Agolzvuv", "Bloated Pearlfrog", "Cyclopean Gibbon", "Mimic", "Molting Basilisk",
                            "Quartz Baboon", "Snailmother", "Urchin Belcher", "Bone Worm", "Goatfolk Qlippoth",
                            "Greater Voider", "Madpole", "Ogre Ape", "Rhinox", "BaseElderBreather", "ElderFireBreather",
                            "ElderIceBreather", "ElderCorrosiveBreather", "ElderNormalityBreather",
                            "ElderPoisonBreather", "ElderSleepBreather", "ElderStunBreather", "ElderConfusionBreather",
                            "Enigma Snail", "Great Saltback", "Kaleidoslug", "Memory Eater", "Sultan Croc", "Svardym",
                            "Saltwurm", "Unimax", "Urshiib", "Dromad", "GolgothaSlog", "BaseBiomech", ]

    print('''<?xml version="1.0" encoding="utf-8"?>
<!-- Undead versions of all creatures that can be reanimated -->
<objects>''')

    for creature in creatures_considered:
        print(f'\t<object Name="ChebGonaz Undead {creature}" Inherits="{creature}">\n'
              f'\t\t<removepart Name="Corpse" />\n'
              f'\t</object>')
    print('</objects>')

    # path_to_xml = pathlib.Path.home().joinpath('.local/share/Steam/steamapps/common/'
    #                                            'Caves of Qud/CoQ_Data/StreamingAssets/Base/ObjectBlueprints/'
    #                                            'Creatures.xml')
    # # can't parse XML because apparently it's malformed? whatever.
    # # root = ElementTree.parse(path_to_xml).getroot()
    #
    # # fish it all out with regex then I guess
    # creatures_considered = ['"Templar"', '"Bat"', '"Pig"', '"Boar"', '"Cave Spider"', '"Ray Cat"', '"Croc"', '"Dog"',
    #                         '"Electrofuge"', '"Giant Beetle"', '"Giant Centipede"', '"GiantDragonfly"', '"Glowfish"',
    #                         '"Goat"', '"Horned Chameleon"', '"Qudzu"', '"Salamander"', '"Scorpiock"', '"Snapjaw"',
    #                         '"Chute Crab"', '"Eyeless Crab"', '"Feral Lah"', '"Girshling"', '"Glowmoth"', '"Knollworm"',
    #                         '"Leech"', '"Salthopper"', '"Seedsprout Worm"', '"Worm of the Earth"', '"Naphtaali"',
    #                         '"BaseHindren"', '"Albino ape"', '"Barkbiter"', '"Chitinous Puma"', '"Dawnglider"',
    #                         '"Equimax"', '"Fire ant"', '"Fire Snout"', '"Ghost Perch"', '"Ice frog"', '"Quillipede"',
    #                         '"Rustacean"', '"Spark Tick"', '"Voider"', '"Goatfolk"', '"Electric Snail"',
    #                         '"Eyeless King Crab"', '"BaseBreather"', '"FireBreather"', '"IceBreather"',
    #                         '"CorrosiveBreather"', '"NormalityBreather"', '"PoisonBreather"', '"SleepBreather"',
    #                         '"StunBreather"', '"ConfusionBreather"', '"Troll"', '"Agolzvuv"', '"Bloated Pearlfrog"',
    #                         '"Cyclopean Gibbon"', '"Mimic"', '"Molting Basilisk"', '"Quartz Baboon"', '"Snailmother"',
    #                         '"Urchin Belcher"', '"Bone Worm"', '"Goatfolk Qlippoth"', '"Greater Voider"', '"Madpole"',
    #                         '"Ogre Ape"', '"Rhinox"', '"BaseElderBreather"', '"ElderFireBreather"',
    #                         '"ElderIceBreather"', '"ElderCorrosiveBreather"', '"ElderNormalityBreather"',
    #                         '"ElderPoisonBreather"', '"ElderSleepBreather"', '"ElderStunBreather"',
    #                         '"ElderConfusionBreather"', '"Enigma Snail"', '"Great Saltback"', '"Kaleidoslug"',
    #                         '"Memory Eater"', '"Sultan Croc"', '"Svardym"', '"Saltwurm"', '"Unimax"', '"Urshiib"',
    #                         '"Dromad"', '"GolgothaSlog"', '"BaseBiomech"', ]
    # result = {}
    # last_key = ''
    # lines = []
    # with open(path_to_xml, 'r', encoding='utf-8') as f:
    #     object_begin_pattern = '<object Name=("[A-Za-z0-9 ]+")'  # Inherits="BaseHumanoid"'
    #     object_end_pattern = '</object>'
    #     for line in f.readlines():
    #         object_match = re.search(object_begin_pattern, line)
    #
    #         if object_match and object_match.group(1) in creatures_considered:
    #             last_key = object_match.group(1)
    #
    #         if last_key == '':
    #             continue
    #
    #         elif object_end_pattern in line:
    #             lines.append(line)
    #             result[last_key] = lines
    #             lines = []
    #             last_key = ''
    #         else:
    #             lines.append(line)
    #
    #     for key, value in result.items():
    #         string_value = "".join(value)
    #         print(string_value)
