import React from 'react'
import { Container } from 'semantic-ui-react'
import DataFetching from '../../DataFetching'
import NavBar from './NavBar'

function App() {
  return (
    <>
      <NavBar />

      <Container style={{ marginTop: '8em' }}>
        <DataFetching />
      </Container>
    </>
  )
}

export default App
