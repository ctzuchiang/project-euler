#!/usr/bin/python3
 
class Parent:        # 定义父类
   def speak(self):
      print ('請給我一杯水')
 
class Child(Parent): # 定义子类
   def speak(self):
      print ('給我f*ck水')
 
c = Child()          # 子类实例
c.speak()         # 子类调用重写方法
super(Child,c).speak() #用子类对象调用父类已被覆盖的方法