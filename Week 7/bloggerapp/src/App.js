import './App.css';
import { Course } from './Course';
import { Book } from './Book';
import { Blog } from './Blog';

function App() {
  return (
    <div className="App">
  <div className="section">
    <h1> Course Details </h1>
    <Course />
  </div>

  <div className="divider"></div>

  <div className="section">
  <h1> Book Details </h1>
    <Book />
  </div>

  <div className="divider"></div>

  <div className="section">
  <h1> BLog Details </h1>
    <Blog />
  </div>
</div>

  );
}

export default App;
