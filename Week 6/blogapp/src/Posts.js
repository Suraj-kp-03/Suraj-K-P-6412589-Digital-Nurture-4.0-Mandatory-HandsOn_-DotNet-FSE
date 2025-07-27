import React from 'react';
import Post from './Post';  
import './App.css'; 

class Posts extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],      
      loading: true,  
      hasError: false 
    };
  }

  // Fetch posts from API
  loadPosts() {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP ${response.status}`);
        }
        return response.json();
      })
      // Map data to Post form
      .then(data => {
        const postModels = data.map(
          item => new Post(item.id, item.title, item.body)
        );
        this.setState({ posts: postModels, loading: false });
      })
      .catch(err => {
        console.error('Fetch error:', err);
        this.setState({ hasError: true, loading: false });
      });
  }

  componentDidMount() {
    this.loadPosts();
  }
  // catch errors
  componentDidCatch(error, info) {

    alert('An error occurred: ' + error.message);
    this.setState({ hasError: true });
  }

  render() {
    const { posts, loading, hasError } = this.state;

    if (loading) {
      return <p>Loading posts…</p>;
    }

    if (hasError) {
      return <p style={{ color: 'red' }}>Sorry, we couldn’t load posts due to Some Errors.</p>;
    }

    return (
      <div>
        <h2>All Posts</h2>
        {posts.map(p => (
          <div key={p.id}>
            <h3>{p.title}</h3>
            <p>{p.body}</p>
          </div>
        ))}
      </div>
    );
  }
}

export default Posts;
