import React, { useEffect, useState, useContext } from "react";
import Post from "./Post";
import PostSearch from "./PostSearch";
import { UserProfileContext } from "../providers/UserProfileProvider";

const PostList = () => {
  const { getToken } = useContext(UserProfileContext);
  const [post, setPosts] = useState([]);

  useEffect(() => {
    getToken().then((token) =>
      fetch("/api/Post", {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((resp) => resp.json())
        .then(setPosts)
    );
  }, []);

  return (
    <>
      <div className="container">
        <div className=".row justify-content-center">
          <div className="cards-column">
            <PostSearch onSearch={setPosts} />
            {post.map((post) => (
              <Post key={post.id} post={post} />
            ))}
          </div>
        </div>
      </div>
    </>
  );
};

export default PostList;
