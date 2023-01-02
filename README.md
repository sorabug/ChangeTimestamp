# ChangeTimestamp
一键修改exe、dll的编译时间、创建时间、修改时间和访问时间

某杀软会对时间较新且未扫描过的文件设置很高的可疑分数，通常大家只会改创建时间和修改时间，而virustotal还会识别**编译时间**，使用本脚本可一键修改**exe**、**dll**的**编译时间**、**创建时间**、**修改时间**和**访问时间**。

灵感来自此项目https://github.com/qigpig/changeTime

### Deployment

- Build：vs2019
- Runtime：NET Framework 4.0
- 可选择对应系统NET Framework环境编译

### Usage 
ChangeTimestamp filepath timestamp
![test](https://github.com/sorabug/ChangeTimestamp/blob/main/test.png)
