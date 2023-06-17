import os
import sys
import pathlib
import xml.etree.ElementTree as ElementTree
import re


class IgnoreErrorsParser(ElementTree.XMLParser):
    def _raiseerror(self, value):
        pass


if __name__ == '__main__':
    path_to_xml = pathlib.Path.home().joinpath('.local/share/Steam/steamapps/common/'
                                               'Caves of Qud/CoQ_Data/StreamingAssets/Base/ObjectBlueprints/'
                                               'Creatures.xml')
    # can't parse XML because apparently it's malformed? whatever.
    # root = ElementTree.parse(path_to_xml).getroot()

    # fish it all out with regex then I guess
    inherits = {}
    lines = []
    last_line = None
    with open(path_to_xml, 'r', encoding='utf-8') as f:
        inherits_pattern = 'Inherits="[A-Za-z0-9]+'
        object_name_pattern = '<object Name="([A-Za-z0-9 ]+)"'# Inherits="BaseHumanoid"'
        corpse_name_pattern = '<part Name="Corpse".+CorpseBlueprint="([A-Za-z0-9 ]+)"'
        for line in f.readlines():
            # inherits_match = re.findall(inherits_pattern, line)
            # if len(inherits_match) > 0 and not inherits_match[0] in inherits:
            #     inherits[inherits_match[0]] = ""

            object_match = re.search(object_name_pattern, line)
            if object_match:
                last_line = object_match.group(1)

            corpse_match = re.search(corpse_name_pattern, line)
            if corpse_match:
                lines.append(f'"{corpse_match.group(1)}" => "{last_line}", ')
        for line in lines:
           print(line)
        # for key in inherits.keys():
        #     print(key)
    #     # for event, element in ElementTree.iterparse(f.read()):
    #     #     if element.tag == 'objects':
    #     #         print("objects")
    #     # Events - signify when to yield a result
    #     events = ('start', 'end')  # Yield on the start and end of a tag
    #
    #     file_contents = f.read()
    #
    #     # Redirect sys.stdout to the null device cuz iterparse is noisy as HELL
    #     sys.stdout = open(os.devnull, 'w')
    #
    #     # It's important to clear the elements when working with bag datasets
    #     for event, element in ElementTree.iterparse(file_contents, events=events):
    #         if event == 'start':
    #             print(element.tag)
    #         if event == 'end':
    #             element.clear()
    #
    #     # Restore the original sys.stdout
    #     sys.stdout = sys.__stdout__


