# Reflection
[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/vicboma1/reflection/trend.png)](https://bitdeli.com/free "Bitdeli Badge")[![Analytics](https://ga-beacon.appspot.com/UA-68658653-1/injector/readme)](https://github.com/igrigorik/ga-beacon)

##Instance
```c#
internal static T CreateInstanceDefaultExpressionLambda(Type instance)
internal static T CreateInstanceConstructor(Type instance)
internal static T CreateInstanceConstructor(Type instance, Type[] typesObject, object[] obj)
internal static T CreateActivatorInstance(Type instance, object[] obj)
internal static T CreateActivatorInstance(Type instance)
internal static T CreateActivatorInstance(String _namespace)
```

##Property
```c#
internal static T GetInstanceProperty(object instance, string propertyName);
```

##Field
```c#
internal static T GetInstanceField(object instance, string fieldName)
```

##Coverage 100%

![](http://i.imgur.com/I9KcngV.png?1)



