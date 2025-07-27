import React from 'react';
import Posts from './Posts';
import './App.css';

class App extends React.Component {
  render() {
    return (
      <div className="App">
        <header>
          <h1>BlogApp</h1>
        </header>
        <main>
          <Posts />
        </main>
      </div>
    );
  }
}

export default App;
