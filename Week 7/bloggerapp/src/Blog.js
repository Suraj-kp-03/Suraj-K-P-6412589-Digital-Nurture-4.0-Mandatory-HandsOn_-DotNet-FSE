import { blogDetails } from "./Details";

export const Blog=()=>{
    return(
        blogDetails.map((blog)=>{
        return(
            <ul>
                <h2>{blog.title}</h2>
                <h3>{blog.author}</h3>
                <h4>{blog.content}</h4>
            </ul>
        )
    })
)
}