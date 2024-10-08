package main

func letterCombinations(digits string) []string {
	res := []string{}
	if digits == "" {
		return res
	}
	dict := map[string]string{
		"2": "abc",
		"3": "def",
		"4": "ghi",
		"5": "jkl",
		"6": "mno",
		"7": "pqrs",
		"8": "tuv",
		"9": "wxyz",
	}
	var dfs func(index int, cur string)
	dfs = func(index int, cur string) {
		if index == len(digits) {
			res = append(res, cur)
			return
		}
		for _, char := range dict[string(digits[index])] {
			dfs(index+1, cur+string(char))
		}
	}
	dfs(0, "")
	return res
}
