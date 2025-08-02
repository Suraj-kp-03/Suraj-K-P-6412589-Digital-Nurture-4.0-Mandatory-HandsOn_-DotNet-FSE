import { courseDetails } from "./Details";

export const Course=()=>{
    return(
        courseDetails.map((course)=>{
        return(
            <ul>
                <h2>{course.name}</h2>
                <h3>{course.date}</h3>
            </ul>
        )
    })
)
}