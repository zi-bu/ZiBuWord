import json
import csv

# 定义 JSON 文件路径和输出的 CSV 文件路径
json_file_path = 'D:/杂/作业/c#小组项目/english-vocabulary-master/json/7-SAT-顺序.json'  # 替换为你的 JSON 文件路径
csv_file_path = 'D:/杂/作业/c#小组项目/english-vocabulary-master/json/csv/7-SAT-顺序.csv'  # 替换为你想要的 CSV 文件路径

# 读取 JSON 文件
with open(json_file_path, 'r', encoding='utf-8') as json_file:
    data = json.load(json_file)

# 确保 JSON 数据是一个列表
if isinstance(data, dict):
    data = [data]

# 写入 CSV 文件
with open(csv_file_path, 'w', newline='', encoding='utf-8') as csv_file:
    csv_writer = csv.writer(csv_file)  

    # 写入表头（假设 JSON 对象的键是表头）
    header = data[0].keys()
    csv_writer.writerow(header)

    # 写入数据
    for row in data:
        csv_writer.writerow(row.values())

print(f"JSON 文件已成功转换为 CSV 文件，保存为 {csv_file_path}")