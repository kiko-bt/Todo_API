export interface Todo {
  id: number
  name: string
  isComplete: boolean
  addedOn: Date
  priority: number
  userId: number
  user: User
}

export interface User {
  id: number
  firstName: string
  lastName: string
  username: string
  password: string
  todoId: number
  todos: string[]
}
