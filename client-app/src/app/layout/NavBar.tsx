import * as React from 'react'
import { Button, Container, Menu } from 'semantic-ui-react'
import { Todo } from './../models/toDo'

export default function NavBar() {
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header>
          <img
            src="/assets/logo.png"
            alt="logo"
            style={{ marginRight: '10px' }}
          />
          Todo
        </Menu.Item>
        <Menu.Item>
          <Button positive content="Create Todo" />
        </Menu.Item>
      </Container>
    </Menu>
  )
}
