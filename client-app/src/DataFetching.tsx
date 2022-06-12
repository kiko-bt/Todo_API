import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { List } from 'semantic-ui-react'
import { Todo } from './app/models/toDo'

function DataFetching() {
  const [todos, setTodos] = useState<Todo[]>([])

  useEffect(() => {
    axios
      .get<any>('https://localhost:7244/todo')
      .then((res) => {
        setTodos(res.data.data)
      })
      .catch((err) => {
        console.log(err)
      })
  }, [])

  return (
    <List>
      {todos.map((todo) => (
        <List.Item key={todo.id}>{todo.name}</List.Item>
      ))}
    </List>
  )
}

export default DataFetching
