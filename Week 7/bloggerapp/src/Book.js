import { bookDetails } from "./Details";

export const Book=()=>{
    return(
        bookDetails.map((book)=>{
        return(
            <ul>
                <h2>{book.bname}</h2>
                <h3>{book.price}</h3>
            </ul>
        )
    })
)
}
