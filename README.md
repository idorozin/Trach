# Trach - A unity mobile game
fast-paced, mobile infinite runner game where you drive a truck, navigating a busy highway. Your goal is simple: **dodge oncoming cars** and collect power-ups along the way to enhance your gameplay. As you speed down the road, the longer you survive, the more challenging the game becomes!

Gameplay video:

**[![Gameplay](https://img.youtube.com/vi/y3YOfKBwVqM/0.jpg)](https://www.youtube.com/watch?v=y3YOfKBwVqM)**

# Intresting systems used in the game
## Object Pooling System

In Unity, frequently calling the `Instantiate` and `Destroy` methods to create and remove objects during gameplay can be resource-intensive. **Object Pooling** is a creational design pattern that addresses this issue by pre-instantiating all the objects you'll need during gameplay. It allows you to reuse objects that are no longer required, avoiding constant creation and destruction.

In infinite runner games, for example, this pattern is crucial for optimizing performance, especially in mobile game development, where reducing memory and CPU usage is key.

### How It Works

Each object that will be pre-instantiated implements the `IPoolableObject` interface. This interface allows objects to be notified when they are returned to the object pool (i.e., "destroyed") or taken out of the object pool (i.e., "created").

The `ObjectPool` class maintains a dictionary that maps each type of game object—like a Red Car, Green Car, Coin, or Fly PowerUp—to a queue that holds available instances of these objects.

Whenever you need to create an object, the `ObjectPool` retrieves one from the pool. If an object is no longer in use, it can be returned to the pool for reuse. If no available object exists in the pool, the `ObjectPool` will instantiate a new one. However, typically, the pool is pre-filled with a sufficient number of objects before the game begins to minimize instantiation during gameplay.

## PowerUp System
