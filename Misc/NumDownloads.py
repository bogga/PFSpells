import requests, json
url = "https://api.github.com/repos/bogga/PFSpells/releases"

response = requests.get(url)
download_data = {}
if response.ok:
    data = json.loads(response.content)
    for item in data:
        if "assets" in item:
            download_data[item['tag_name']] = item['assets'][0]['download_count']

print("{0:<9} {1:<9}".format("version", "downloads"))
for i in download_data:
    print("{0:<9} {1:<3}".format(i, download_data[i]))
print("Total downloads: {0}".format(sum(download_data.values())))