#1 2 3 4 5 6 7 8 9 10 を表示


# for n in range(1,11):
#     print(n, "   ",end="   ")

#3と表示させる
# a = 5
# b = 3
# a,b = b,a
# print(a,b)

# a=[1,2]
# b=[3,4]
# s=0

# for n,m in enumerate(a+b):
#     s = s + n * m
# print(s)#20が出力

# for i in enumerate(a):
#     print(i)
    
# for i in zip(a,b):
#     print(i)#20が出力

# cities = ['Tokyo','Paris','London','Berlin','New York']
# for index,city in enumerate(cities):
#     print(index,city)

# num = 0
# while num < len(cities):
#     print(cities[num])
#     num+=1

# numbers = [1,2,3,4,5,6,7,8,9,10]
# for number in numbers:
#     if number % 2 == 0:
#         print(number)
#     else:
#         print('kisuu')

# print('数値を入力')  #100以上は合格(100未満は不合格)
# num = input()
# if int(num) >=100:
#     print('合格')
# else:
#     print('不合格')

# member = {'name':'坂本龍馬','age':28,'gender':'male'}
# print(member['name'])

# def func():
#     a = 1
#     b = 2
#     c = a + b
#     print(c)

# func()

from dataclasses import dataclass


@dataclass  #クラスの定義
class Item:
    kind : str
    price : int
    
def tax_included_price(item):
    if item.kind == "food":
        return round(item.price * 1.08)
    else:
        return item.price * 1.1
        
def total_amount(items):
    amounts = [tax_included_price(item) for item in items]
    return sum(amounts)

    items = [Item("food",200),
             Item("book",1000),
             Item("food",100),]
    print(items[0])