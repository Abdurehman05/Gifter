import React from "react";

const PostForm = () => {
    const { addPost } = {}


    const handleControlledInputChange = (event) => {
        addPost[event.target.id] = event.target.value
        addPost.userProfileId = parseInt(addPost.userProfileId)
        addPost.dateCreated = Date.now();

    }
    const clickSavePost = (event) => {
        event.preventDefault()
        submitPost(addPost)

    }
    const submitPost = postObj => {
        return fetch('/api/Post', {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(postObj)
        })
    };


    return (
        <section className="addPostForm">
            <h2 className="addPostFormTitle">New Post</h2>
            <form id="addPostForm">
                <fieldset>
                    <div className="form-group">
                        <label htmlFor="Title">Title: </label><br />
                        <input type="text" id="title" name="title" onChange={handleControlledInputChange} />
                    </div>
                </fieldset>

                <fieldset>
                    <div className="form-group">
                        <label htmlFor="ImageUrl">Image URL: </label><br />
                        <input type="text" id="imageUrl" name="imageUrl" onChange={handleControlledInputChange} />
                    </div>
                </fieldset>

                <fieldset>
                    <div className="form-group">
                        <label htmlFor="Caption">Caption: </label><br />
                        <input type="text" id="caption" name="caption" onChange={handleControlledInputChange} />
                    </div>
                </fieldset>

                <fieldset>
                    <div className="form-group">
                        <label htmlFor="UserProfileId">User Profile ID: </label><br />
                        <input type="text" id="userProfileId" name="userProfileLd" onChange={handleControlledInputChange} />
                    </div>
                </fieldset>

                <button onClick={clickSavePost}>Add Post</button>

            </form>
        </section>
    )
}

export default PostForm;